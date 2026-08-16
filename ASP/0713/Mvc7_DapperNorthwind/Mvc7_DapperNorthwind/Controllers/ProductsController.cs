using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Mvc7_DapperNorthwind.Models;

namespace Mvc7_DapperNorthwind.Controllers
{
    #nullable disable
    public class ProductsController : Controller
    {
        private readonly NorthwindContext _ctx;
        private readonly IConfiguration _config;
        private readonly string _connString;
        public ProductsController(NorthwindContext ctx, IConfiguration config)
        {
            _ctx = ctx;
            _config = config;
            _connString = config.GetConnectionString("NorthwindContext");
        }

        public IActionResult Index()
        {
            //var northwindContext = _context.Products.Include(p => p.Category).Include(p => p.Supplier);

            List<Product> products = null;

            using (var conn = new SqlConnection(_config.GetConnectionString("NorthwindContext")))
            {
                string sql = "select * from products";
                products = conn.QueryAsync<Product>(sql).Result.ToList();
            }

            return View(products);
        }

        //By convention, if an action method’s name ends with Async,
        //the Async suffix is removed from the action name when matching a URL
        //MvcOptions.SuppressAsyncSuffixInActionNames Property

        public async Task<IActionResult> ListAsync()
        {
            //var northwindContext = _context.Products.Include(p => p.Category).Include(p => p.Supplier);

            string sql = "select * from products";
            IEnumerable<Product> products = null;

            using (var conn = new SqlConnection(_config.GetConnectionString("NorthwindContext")))
            {
                await conn.OpenAsync();
                products = await conn.QueryAsync<Product>(sql).ConfigureAwait(false);
            }

            return View("Index", products.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<Category> categories = null;
            List<Supplier> suppliers = null;
            using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("NorthwindContext")))
            {
                string sql1 = "select * from Categories";
                string sql2 = "select * from Suppliers";
                categories = conn.Query<Category>(sql1).ToList();
                suppliers = conn.Query<Supplier>(sql2).ToList();
            }

            ViewData["CategoryId"] = new SelectList(categories, "CategoryId", "CategoryName");
            ViewData["SupplierId"] = new SelectList(suppliers, "SupplierId", "CompanyName");

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateMethodAsync()
        {
            // 使用Task.WhenAll同时执行两个查询任务
            using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("NorthwindContext")))
            {
                await conn.OpenAsync();

                string sql1 = "select * from Categories";
                string sql2 = "select * from Suppliers";

                // 创建两个异步任务并同时执行
                var categoriesTask = conn.QueryAsync<Category>(sql1);
                var suppliersTask = conn.QueryAsync<Supplier>(sql2);

                // 等待两个任务都完成
                await Task.WhenAll(categoriesTask, suppliersTask);

                // 获取结果
                var categories = (await categoriesTask).ToList();
                var suppliers = (await suppliersTask).ToList();

                ViewData["CategoryId"] = new SelectList(categories, "CategoryId", "CategoryName");
                ViewData["SupplierId"] = new SelectList(suppliers, "SupplierId", "CompanyName");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ProductId,ProductName,SupplierId,CategoryId,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued")] Product product)
        {
            if (ModelState.IsValid)
            {
                int affectedRow = 0;    //

                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("NorthwindContext")))
                {
                    string sql = "INSERT INTO Products (ProductName,SupplierId,CategoryId,QuantityPerUnit,Discontinued) VALUES ( @ProductName,@SupplierId,@CategoryId,@QuantityPerUnit, @Discontinued)";
                            
                    affectedRow = conn.Execute(sql, product);
                }
                //_context.Add(product);
                //await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            List<Category> categories = null;
            List<Supplier> suppliers = null;
            using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("NorthwindContext")))
            {
                string sql1 = "select * from Categories";
                string sql2 = "select * from Suppliers";
                categories = conn.Query<Category>(sql1).ToList();
                suppliers = conn.Query<Supplier>(sql2).ToList();
            }


            ViewData["CategoryId"] = new SelectList(categories, "CategoryId", "CategoryName");
            ViewData["SupplierId"] = new SelectList(suppliers, "SupplierId", "CompanyName");
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMethodAsync([Bind("ProductId,ProductName,SupplierId,CategoryId,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued")] Product product)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("NorthwindContext")))
                {
                    await conn.OpenAsync();
                    string sql = "INSERT INTO Products (ProductName,SupplierId,CategoryId,QuantityPerUnit,Discontinued) VALUES (@ProductName,@SupplierId,@CategoryId,@QuantityPerUnit,@Discontinued)";

                    int affectedRow = await conn.ExecuteAsync(sql, product);
                }

                return RedirectToAction(nameof(Index));
            }

            // 如果ModelState无效，准备下拉列表数据
            using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("NorthwindContext")))
            {
                await conn.OpenAsync();

                string sql1 = "select * from Categories";
                string sql2 = "select * from Suppliers";

                // 并行执行查询
                var categoriesTask = conn.QueryAsync<Category>(sql1);
                var suppliersTask = conn.QueryAsync<Supplier>(sql2);

                await Task.WhenAll(categoriesTask, suppliersTask);

                var categories = (await categoriesTask).ToList();
                var suppliers = (await suppliersTask).ToList();

                ViewData["CategoryId"] = new SelectList(categories, "CategoryId", "CategoryName", product.CategoryId);
                ViewData["SupplierId"] = new SelectList(suppliers, "SupplierId", "CompanyName", product.SupplierId);
            }

            return View(product);
        }
    }
}
