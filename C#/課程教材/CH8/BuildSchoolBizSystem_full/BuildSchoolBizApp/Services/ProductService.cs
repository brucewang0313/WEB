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
    public class ProductService
    {
        private readonly BizRepository _repository;
        public ProductService(BizRepository repository)
        {
            _repository = repository;
        }
        public OperationResult Create(ProductViewModel input)
        {
            var result = new OperationResult();
            try
            {
                var entity = new Product
                {
                    PartNo = input.PartNo!,
                    PartName = input.PartName!
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

        public IEnumerable<ProductViewModel> GetAll()
        {
            foreach (var item in _repository.GetAll<Product>().OrderBy(x => x.PartNo))
            {
                yield return new ProductViewModel
                {
                    PartNo = item.PartNo,
                    PartName = item.PartName
                };
            }
        }
    }
}
