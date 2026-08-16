using BizDataLibrary.Models;
using BizDataLibrary.Repositories;
using BuildSchoolBizApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuildSchoolBizApp.Services
{
    public class SellingService
    {
        private readonly BizRepository _repository;
        public SellingService(BizRepository repository)
        {
            _repository = repository;
        }
        private Selling CreatSelling(SellingViewModel input)
        {
            Selling entity = new Selling()
            {
                PartNo = input.PartNo!,
                Quantity = input.Quantity,
                SalesJobNumber = input.SalesJobNumber,
                SellingDay = input.SellingDay,
                UnitPrice = input.UnitPrice,
            };
            _repository.Create(entity);// 要先 SaveChanges , 才能拿到 Selling.SellingId
            _repository.SaveChanges();
            return entity;
        }
        private void CreateSellingSource(int sellingId, int procurementId,int sellQuantity)
        {
            SellingSource entity = new SellingSource()
            {
                SellingId = sellingId,
                ProcurementId = procurementId,
                Quantity = sellQuantity
            };
            _repository.Create(entity);
        }
        private void UpdateProcurementInvemtory(SellingViewModel input)
        {
            Selling entity = CreatSelling(input);
            var remainQuantity = input.Quantity;
            var procurements = _repository.GetAll<Procurement>()
            .Where(p => p.PartNo == input.PartNo && p.InvetoryQuantity > 0)
            .OrderBy(p => p.PurchasingDay);
            foreach (var p in procurements)
            {
                if (remainQuantity <= 0)
                {
                    break;
                }
                if (p.InvetoryQuantity >= remainQuantity)
                {
                    // 出貨量小於等於庫存量
                    CreateSellingSource(entity.SellingId, p.ProcurementId, remainQuantity);
                    p.InvetoryQuantity -= remainQuantity;
                    remainQuantity = 0;
                }
                else
                {
                    // 出貨量大於庫存量
                    CreateSellingSource(entity.SellingId, p.ProcurementId, p.InvetoryQuantity);
                    remainQuantity -= p.InvetoryQuantity;
                    p.InvetoryQuantity = 0;
                }
            }

        }
        public OperationResult Create(SellingViewModel input)
        {
            var result = new OperationResult();
            // 使用交易處理，確保資料一致性，這裡採用舊式的 using 語法
            using (var transaction= _repository.BeginTransaction())
            {
                try
                {
                    UpdateProcurementInvemtory(input);
                    _repository.SaveChanges();
                    transaction.Commit();
                    result.IsSuccessful = true;
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    result.IsSuccessful = false;
                    result.Exception = ex;
                }
            }
            return result;
        }
        public IEnumerable<SellingQueryViewModel> GetSellingBySalesAndDay(int jobNumber, DateTime begin, DateTime end)
        {
            return from selling in _repository.GetAll<Selling>()
                   join sales in _repository.GetAll<Salesman>()
                   on selling.SalesJobNumber equals sales.JobNumber
                   where selling.SalesJobNumber == jobNumber
                   && selling.SellingDay >= begin
                   && selling.SellingDay < end
                   select new SellingQueryViewModel
                   {
                       SellingId = selling.SellingId,
                       SalesJobNumber = sales.JobNumber,
                       SalesName = sales.Name,
                       PartNo = selling.PartNo,
                       SellingDay = selling.SellingDay,
                       Quantity = selling.Quantity,
                       UnitPrice = selling.UnitPrice,
                   };
        }
    }
    
}
