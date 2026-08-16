//using BizDataLibrary.Models;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BizDataLibrary.Repositories
//{
//    public class SalesManRepository : BizRepository
//    {
//        public SalesManRepository(BizContext context) : base(context)
//        {

//        }
//        public Salesman? Get(int jobNumber)
//        {
//            return _context.Salesmen.FirstOrDefault((s => s.JobNumber == jobNumber));
//        }
//    }
//}
