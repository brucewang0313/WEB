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
    public class SalesmanService
    {
        private readonly BizRepository _repository;
        public SalesmanService(BizRepository repository)
        {
            _repository = repository;
        }

        public OperationResult Create(SalesmanViewModel input)
        {
            var result = new OperationResult();
            try
            {
                var entity = new Salesman
                {                    
                    Name = input.Name!
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

        public IEnumerable<SalesmanViewModel> GetAll()
        {
            return _repository.GetAll<Salesman>()
                 .Select(s => new SalesmanViewModel
                 {
                     JobNumber = s.JobNumber,
                     Name = s.Name
                 }).AsEnumerable();
        }
    }
}
