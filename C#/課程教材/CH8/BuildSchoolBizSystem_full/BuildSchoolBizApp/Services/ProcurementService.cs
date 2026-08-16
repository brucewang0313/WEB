using BizDataLibrary.Models;
using BizDataLibrary.Repositories;
using BuildSchoolBizApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSchoolBizApp.Services
{
    public class ProcurementService
    {
        private readonly BizRepository _repository;
        public ProcurementService(BizRepository repository)
        {
            _repository = repository;
        }

        public OperationResult Create(ProcurementViewModel input)
        {
            var result = new OperationResult();
            try
            {
                var entity = new Procurement
                {
                    PartNo = input.PartNo!,
                    Quantity = input.Quantity,
                    InvetoryQuantity = input.InvetoryQuantity,
                    UintPrice = input.UintPrice,
                    PurchasingDay = input.PurchasingDay
                };
                _repository.Create(entity);
                _repository.SaveChanges();
                result.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                result.IsSuccessful = false;
                result.Exception = ex;
            }
            return result;
        }

        /// <summary>
        /// 取得某料號的庫存數量
        /// </summary>
        /// <param name="partNo"></param>
        /// <returns></returns>
        public int GetInventoryQuantity(string partNo)
        {
            return _repository.GetAll<Procurement>()
                              .Where(p => p.PartNo == partNo && p.InvetoryQuantity > 0)
                              .Sum(p => p.InvetoryQuantity);
        }

        /// <summary>
        /// 查詢各產品的庫存總量
        /// </summary>
        /// <returns></returns>
        public IEnumerable<InventoryQueryViewModel> GetInventorySummary()
        {
            var temp = from p in _repository.GetAll<Product>()
                       join q in _repository.GetAll<Procurement>()
                       on p.PartNo equals q.PartNo
                       select new
                       {
                           PartNo = p.PartNo,
                           PartName = p.PartName,
                           InvetoryQuantity = q.InvetoryQuantity
                       };
            return from t in temp
                   group t by new { t.PartNo, t.PartName } into g
                   select new InventoryQueryViewModel
                   {
                       PartNo = g.Key.PartNo,
                       PartName = g.Key.PartName,
                       TotalInventoryQuantity = g.Sum(x => x.InvetoryQuantity)
                   };
        }
    }
}
