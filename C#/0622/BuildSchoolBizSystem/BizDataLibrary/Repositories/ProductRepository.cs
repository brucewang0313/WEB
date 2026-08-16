//using BizDataLibrary.Models;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BizDataLibrary.Repositories
//{
//    public class ProductRepository : BizRepository
//    {
//        public ProductRepository(BizContext context):base(context)
//        {

//        }
//        public Product? Get(string partNo)
//        {
//            return _context.Products.FirstOrDefault(p => p.PartNo == partNo);
//        }
//    }
//}
