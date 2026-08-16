using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace EFCore_CodeFirstExistingDB.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;

        private readonly NorthwindContext _context;

        public ProductsController(NorthwindContext context, ILogger<ProductsController> logger)
        {
            _context = context;

            //讀取DbContext使用的資料庫連線
            string conn = _context.Database.GetDbConnection().ConnectionString;

            _logger = logger;
        }


        //查詢所有資料
        public async Task<IActionResult> QueryAllData()
        {
            //非同步
            List<Product> products = await _context.Products.ToListAsync();
            var employees = await _context.Employees.ToListAsync();

            //同步
            List<Order> orders = _context.Orders.ToList();
            var orderDetails = _context.OrderDetails.ToList();

            return View(products);
        }


        //查詢單一筆Entity資料
        public async Task<IActionResult> QuerySingleData(int Id = 1)
        {
            //非同步
            var p1 = await _context.Products.FindAsync(Id);
            var p2 = await _context.Products.FirstAsync();
            var p3 = await _context.Products.FirstOrDefaultAsync();
            var p4 = await _context.Products.SingleAsync(p => p.ProductId == 1);
            var p5 = await _context.Products.SingleOrDefaultAsync(p => p.ProductId == 1);

            //同步
            var p6 = _context.Products.Find(Id);
            var p7 = _context.Products.First();
            var p8 = _context.Products.FirstOrDefault();
            var p9 = _context.Products.Single(p => p.ProductId == 1);
            var p10 = _context.Products.SingleOrDefault(p => p.ProductId == 1);

            return View(p1);
        }

        //First(), FirstOrDefault(), Single(), SingleOrDefault()方法
        //在面對各種不同Source, Sequence和查詢結果時之差異
        public IActionResult FirstSingle()
        {
            string[] source1 = null; //source is null
            var s1 = source1.First(null); //ArgumentNullException: Value cannot be null. (Parameter 'source')
            //var s2 = source1.FirstOrDefault(null);  //ArgumentNullException: Value cannot be null. (Parameter 'source')
            var s3 = source1.Single(null);  //ArgumentNullException: Value cannot be null. (Parameter 'source')
            //var s4 = source1.SingleOrDefault(null); //ArgumentNullException: Value cannot be null. (Parameter 'source')
            var s5 = source1.First();   //ArgumentNullException: Value cannot be null. (Parameter 'source')
            var s6 = source1.FirstOrDefault();  //ArgumentNullException: Value cannot be null. (Parameter 'source')
            var s7 = source1.Single();  //ArgumentNullException: Value cannot be null. (Parameter 'source')
            var s8 = source1.SingleOrDefault(); //ArgumentNullException: Value cannot be null. (Parameter 'source')
            var s9 = source1.First(s => s.Contains("t"));   //ArgumentNullException: Value cannot be null. (Parameter 'source')
            var s10 = source1.FirstOrDefault(s => s.Contains("t"));   //ArgumentNullException: Value cannot be null. (Parameter 'source')
            var s11 = source1.Single(s => s.Contains("t"));   //ArgumentNullException: Value cannot be null. (Parameter 'source')
            var s12 = source1.SingleOrDefault(s => s.Contains("t"));   //ArgumentNullException: Value cannot be null. (Parameter 'source')

            string[] source2 = { }; //source is {string[0]}
            var s21 = source2.First(null); //ArgumentNullException: Value cannot be null. (Parameter 'predicate')
            //var s22 = source2.FirstOrDefault();  //ArgumentNullException: Value cannot be null. (Parameter 'predicate')
            var s23 = source2.Single(null); //ArgumentNullException: Value cannot be null. (Parameter 'predicate')
            //var s24 = source2.SingleOrDefault();  //ArgumentNullException: Value cannot be null. (Parameter 'predicate')
            var s25 = source2.First();   //InvalidOperationException: Sequence contains no elements
            var s26 = source2.FirstOrDefault();  //null
            var s27 = source2.Single(); //InvalidOperationException: Sequence contains no elements
            var s28 = source2.SingleOrDefault();  //null
            var s29 = source2.First(s => s.Contains("t"));  //InvalidOperationException: Sequence contains no matching element
            var s30 = source2.FirstOrDefault(s => s.Contains("t"));  //null
            var s31 = source2.Single(s => s.Contains("t"));  //InvalidOperationException: Sequence contains no matching element
            var s32 = source2.SingleOrDefault(s => s.Contains("t"));  //null

            string[] source3 = { "Apple", "Orange", "Banana" }; //source is {string[3]}
            var s41 = source3.First(null); //ArgumentNullException: Value cannot be null. (Parameter 'predicate')
            //var s42 = source3.FirstOrDefault(null);  //ArgumentNullException: Value cannot be null. (Parameter 'predicate')
            var s43 = source3.Single(null); //ArgumentNullException: Value cannot be null. (Parameter 'predicate')
            //var s44 = source3.SingleOrDefault(null);  //ArgumentNullException: Value cannot be null. (Parameter 'predicate')
            var s45 = source3.First();   //Apple
            var s46 = source3.FirstOrDefault();  //Apple
            var s47 = source3.Single();   //InvalidOperationException: Sequence contains more than one element
            var s48 = source3.SingleOrDefault();  //InvalidOperationException: Sequence contains more than one element
            var s49 = source3.First(s => s.Contains("t"));  //InvalidOperationException: Sequence ,ontains no matching element
            var s50 = source3.FirstOrDefault(s => s.Contains("t"));  //null
            var s51 = source3.Single(s => s.Contains("t"));  //InvalidOperationException: Sequence contains no matching element
            var s52 = source3.SingleOrDefault(s => s.Contains("t"));  //null
            var s53 = source3.Single(s => s.Contains("a"));  //InvalidOperationException: Sequence contains more than one matching element
            var s54 = source3.SingleOrDefault(s => s.Contains("a"));  //InvalidOperationException: Sequence contains more than one matching element
            var s55 = source3.First(s => s.Contains("Ora"));  //Orange
            var s56 = source3.FirstOrDefault(s => s.Contains("Ora"));  //Orange
            var s57 = source3.Single(s => s.Contains("Ora"));  //Orange
            var s58 = source3.SingleOrDefault(s => s.Contains("Ora"));  //Orange

            return Ok("Finished.");
        }

        //以條件式過濾資料
        public async Task<IActionResult> FilteringData()
        {
            //非同步語法
            //Query Syntax查詢語法
            var p1 = await (from p in _context.Products
                            where p.UnitPrice >= 10 && p.UnitPrice <= 15
                            orderby p.ProductName, p.UnitPrice
                            select p)
                            .ToListAsync();

            //Method Syntax方法語法
            var p2 = await _context.Products
                            .Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 15)
                            .OrderBy(p => p.ProductName).ThenBy(p => p.UnitPrice)
                            .ToListAsync();

            //同步語法
            var p3 = (from p in _context.Products
                      where p.UnitPrice >= 10 && p.UnitPrice <= 15
                      orderby p.ProductName descending, p.UnitPrice ascending
                      select p)
                      .ToList();

            var p4 = (_context.Products
                      .AsEnumerable()
                      .Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 15))
                      .OrderByDescending(p => p.ProductName).ThenByDescending(p => p.UnitPrice)
                      .ToList();

            var p5 = (_context.Products
                      .AsQueryable()
                      .Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 15))
                      .OrderByDescending(p => p.ProductName).ThenByDescending(p => p.UnitPrice)
                      .ToList();

            return View(p1);
        }

        //多個資料來源的Inner Join查詢
        public async Task<IActionResult> TablesJoin()
        {
            //1.兩個資料來源 - anonymous匿名型別
            var innerJoin1 = from cate in _context.Categories
                             join prod in _context.Products on cate.CategoryId equals prod.CategoryId
                             select new { Name = prod.ProductName, Category = cate.CategoryName };

            //取得LINQ轉譯後的SQL陳述式
            string sql = innerJoin1.ToQueryString();

            //2.兩個資料來源 - anonymous匿名型別
            var innerJoin2 = from cate in _context.Set<Category>()
                             join prod in _context.Set<Product>() on cate.CategoryId equals prod.CategoryId
                             select new { Name = prod.ProductName, Category = cate.CategoryId };

            //3.三個資料來源 - 使用OrdersViewModel強型別
            var innerJoin3 = from orders in _context.Orders.TagWith("3 Tables inner join")
                             join odetails in _context.OrderDetails on orders.OrderId equals odetails.OrderId
                             join prods in _context.Products on odetails.ProductId equals prods.ProductId
                             select new OrdersViewModel { ProductId = odetails.ProductId, ProductName = prods.ProductName, OrderId = orders.OrderId, UnitPrice = odetails.UnitPrice, OrderDate = orders.OrderDate, ShipAddress = orders.ShipAddress, ShipCity = orders.ShipCity, ShipCountry = orders.ShipCity };

            //4.四個資料來源 - anonymous匿名型別
            var innerJoin4 = from customer in _context.Customers.TagWith("4 Tables inner join")
                             join order in _context.Orders on customer.CustomerId equals order.CustomerId
                             join details in _context.OrderDetails on order.OrderId equals details.OrderId
                             join prod in _context.Products on details.ProductId equals prod.ProductId
                             select new { order.OrderId, customer.CompanyName, customer.ContactName, details.ProductId, prod.ProductName, details.UnitPrice, details.Quantity };

            //四個資料來源 - 使用OrderViewModel
            var innerJoin5 = from customer in _context.Customers.TagWith("Multi Tables inner join")
                             join order in _context.Orders on customer.CustomerId equals order.CustomerId
                             join details in _context.OrderDetails on order.OrderId equals details.OrderId
                             join prod in _context.Products on details.ProductId equals prod.ProductId
                             select new OrderViewModel
                             {
                                 OrderId = order.OrderId,
                                 CompanyName = customer.CompanyName,
                                 ContactName = customer.ContactName,
                                 ProductId = details.ProductId,
                                 ProductName = prod.ProductName,
                                 UnitPrice = details.UnitPrice,
                                 Quantity = details.Quantity
                             };

            var result = await innerJoin4.ToListAsync();
            return Json(result);

            //string json = Newtonsoft.Json.JsonConvert.SerializeObject(result);
            //return Content(json, "application/json");
        }

        public async Task<IActionResult> SkipTake()
        {
            var products = from p in _context.Products
                           where p.UnitPrice >= 10 && p.UnitPrice <= 15
                           orderby p.ProductName descending, p.UnitPrice ascending
                           select p;

            //Skip(5)跳過前5筆, 然後Take(10)取10筆
            var query = await products.Skip(5).Take(10).ToListAsync();

            return View(query);
        }

        //IQuerable<T> vs. IEnumerable<T> vs. ToList()
        public IActionResult QueryType()
        {
            DbSet<Product> pd1 = _context.Products;
            var pd2 = _context.Set<Region>();

            //1.Lazy Loading延後執行,盡可能將Expression轉換成完整伺服端SQL語法, 僅回傳必要結果到記憶體
            IQueryable<Product> products = _context.Products.TagWith("IQueryable")
                                             .Where(p => p.UnitPrice > 10);

            foreach (var i in products)
            {
                Console.WriteLine($"{i.ProductId}, {i.ProductName}, {i.UnitPrice}, {i.UnitsInStock}");
            }

            //2.Lazy Loading延後執行, 將資料全部載入記憶體後,再執行後續的操作
            IEnumerable<Product> prods = _context.Products.TagWith("IEnumerable")
                                           .AsEnumerable()
                                           .Where(p => p.UnitPrice > 20);

            //輸出結果到命令視窗
            prods.ToList().ForEach(p => { Console.WriteLine($"{p.ProductId}, {p.ProductName}, {p.UnitPrice}, {p.UnitsInStock}"); });

            //3.立即執行，在記憶體中建立List<T>集合物件
            List<Product> prodList = _context.Products.TagWith("ToList()")
                                       .Where(p => p.UnitPrice > 30)
                                       .ToList();

            //4.Include OrderDetails相關資料
            var pds = _context.Products
                            .Where(p => p.UnitPrice > 40)
                            .Include(p => p.OrderDetails)
                            .ToList();

            //此設定解決上面Include()方法包含OrderDetails實體所引起的EF循環參考
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string json = JsonConvert.SerializeObject(pds);

            return View(products);
        }


        //FromSql方法只支援EF Core 7.0
        //FromSql() - 基於字插字串所表示的SQL query上所建立的LINQ查詢
        //$"...{param}"字串插值中的{param}參數會包裝成DbParameter形式,可避免SQL Injection攻擊
        public async Task<IActionResult> FromSql()
        {
            //1.以條件式查詢Product資料表中價格大於等於10元之產品 - 全部欄位
            var productsQuery1 = await _context.Products
                                     .FromSql($"Select * from Products where unitprice>=10")
                                     .ToListAsync();

            productsQuery1.ForEach(p => { Console.WriteLine($"{p.ProductId}, {p.ProductName}, {p.UnitPrice}, {p.UnitsInStock}"); });

            //2.以條件式查詢Product資料表中價格大於等於20元之產品 - 部分欄位
            decimal price = 20m;
            var productsQuery2 = await _context.Products
                                    .FromSql($"Select ProductId,ProductName,UnitPrice,UnitsInStock from dbo.Products where UnitPrice >= {price}")
                                    .Select(p => new ProductViewModel { Id = p.ProductId, Name = p.ProductName, UnitPrice = p.UnitPrice, UnitsInStock = p.UnitsInStock })
                                    .AsNoTracking()
                                    .ToListAsync();

            //3.以參數查詢
            price = 30m;
            int stock = 20;

            var productsQuery3 = _context.Products
                        .FromSql($"Select ProductId,ProductName,UnitPrice,UnitsInStock from dbo.Products where UnitPrice >= {price} and UnitsInStock <= {stock}")
                        .Select(p => new ProductViewModel { Id = p.ProductId, Name = p.ProductName, UnitPrice = p.UnitPrice, UnitsInStock = p.UnitsInStock})
                        .AsNoTracking()
                        .ToListAsync();


            //4.呼叫GetAllEmployees預存程序
            var allEmployees = await _context.Employees
                                       .FromSql($"EXECUTE dbo.GetAllEmployees")
                                       .ToListAsync();

            //5.呼叫FindEmployeeByName預存程序, 並傳入參數
            string firstName = "King";
            string lastName = "Robert";
            var findEmployee = await _context.Employees
                                       .FromSql($"EXECUTE dbo.FindEmployeeByName {firstName},{lastName}")
                                       .ToListAsync();

            //6.FromSqlInterpolated插入字串
            var findPerson = await _context.Employees
                                     .FromSqlInterpolated($"EXECUTE dbo.FindEmployeeByName {firstName},{lastName}")
                                     .ToListAsync();

            //取得LINQ轉譯後的SQL陳述式
            string sql = _context.Employees.FromSqlInterpolated($"EXECUTE dbo.FindEmployeeByName {firstName},{lastName}").ToQueryString();


            //7.用SqlQuery方法查詢Scalar純量
            //SqlQuery方法適合查詢純量、非實體類型
            int number = 10;
            IQueryable<int> ids = _context.Database.SqlQuery<int>($"Select ProductId from Products where ProductId>= {number}");            
            IEnumerable<int> idsAsc = _context.Database.SqlQuery<int>($"Select ProductId from Products where UnitPrice >= {number}").AsEnumerable().OrderBy(p => p);
            List<int> idsDesc = _context.Database.SqlQuery<int>($"Select ProductId from Products where UnitsInStock <= {number}").AsEnumerable().OrderByDescending(p => p).ToList();

            return View(productsQuery1);
        }


        //FromSqlRaw方法適用EF Core 3.0, 3.1, 5.0, 6.0, 7.0
        //FromSqlRaw方法中的SQL語法是單純字串
        //FromSqlRaw及SqlQueryRaw方法可動態建構SQL
        public async Task<IActionResult> FromSqlRaw()
        {
            //1.使用FromSqlRaw()送出原生SQL查詣字串
            var productsSql = await _context.Products
                                      .FromSqlRaw("Select * from dbo.Products")
                                      .Select(p => new ProductViewModel { Id = p.ProductId, Name = p.ProductName, UnitPrice = p.UnitPrice, UnitsInStock = p.UnitsInStock })
                                      .OrderBy(p=>p.Name)
                                      .AsNoTracking()
                                      .ToListAsync();

            //2.呼叫GetAllEmployees預存程序
            var allEmployees = await _context.Employees
                                       .FromSqlRaw("EXECUTE dbo.GetAllEmployees")
                                       .ToListAsync();

            //取得LINQ轉譯後的SQL陳述式
            string sql = _context.Employees.FromSqlRaw("EXECUTE dbo.FindEmployeeByName {0},{1}", "King", "Robert").ToQueryString();


            //3.呼叫FindEmployeeByName預存程序, 並傳入參數
            var findEmployee = await _context.Employees
                                       .FromSqlRaw("EXECUTE dbo.FindEmployeeByName {0},{1}", "King", "Robert")
                                       .ToListAsync();

            //4.用FromSqlRaw及SqlQueryRaw方法動態建構SQL
            string columnName = "Country";
            string columnValue = "USA";
            var employees = _context.Employees.FromSqlRaw($"Select * Employees Where {columnName} = @columnValue", columnValue);
            
            var empIds = _context.Database.SqlQueryRaw<int>($"Select EmployeeId From Employees Where {columnName} = @columnValue", columnValue);

            return View(productsSql);
        }

        //執行Update及Delete非查詢類的SQL語法
        public async Task<IActionResult> UpdateDelete()
        {
            //1.ExecuteSql更新資料
            decimal newPrice = 18m;
            await _context.Database.ExecuteSqlAsync($"Update Products set UnitPrice={newPrice} where ProductId=1");

            //2.ExecuteSql刪除資料
            int productId = 92;
            await _context.Database.ExecuteSqlAsync($"Delete from Products where ProductId={productId}");

            //3.ExecuteUpdate更新資料(EF Core 7.0新功能)
            newPrice = 18.8m;
            int affectedRows =await _context.Products
                            .Where(p => p.ProductId == 1)
                            .ExecuteUpdateAsync(p => p.SetProperty(c => c.UnitPrice, newPrice));

            Console.WriteLine($"受影響的資料列數 : {affectedRows}");

            //4.ExecuteDelete刪除資料(EF Core 7.0新功能)
            productId = 1093;
            await _context.Products.Where(p => p.ProductId == productId).ExecuteDeleteAsync();

            //5.ExecuteSqlInterpolated更新資料
            newPrice = 25m;
            productId = 84;
            await _context.Database.ExecuteSqlInterpolatedAsync($"Update Products set UnitPrice={newPrice} where ProductId={productId}");

            //6.ExecuteSqlInterpolated刪除資料
            productId = 85;
            await _context.Database.ExecuteSqlInterpolatedAsync($"Delete from Products where ProductId={productId}");

            return NoContent();
        }

        //LINQ模擬SQL In子句
        public IActionResult InOperator()
        {
            List<int> Ids = new List<int>() { 1, 3, 5, 7, 9};

            var emps = _context.Employees.Where(emp => Ids.Contains(emp.EmployeeId));

            ViewData["SQL"] = emps.ToQueryString();

            return View(emps);
        }


        public async Task<IActionResult> Index()
        {
            //LINQ to Entity
            var products = await (from p in _context.Products
                                  select new ProductViewModel
                                  {
                                      Id = p.ProductId,
                                      Name = p.ProductName,
                                      UnitPrice = p.UnitPrice,
                                      UnitsInStock = p.UnitsInStock,
                                      UnitsOnOrder = p.UnitsOnOrder
                                  })
                                  .AsNoTracking()
                                  .ToListAsync();

            return View(products);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //查詢包含所有欄位
            var product = await _context.Products
                                .FirstOrDefaultAsync(p => p.ProductId == id);

            //查詢只包含指定欄位
            ProductViewModel prod = await _context.Products
                    .Where(p => p.ProductId == id)
                    .Select(p => new ProductViewModel { Id = p.ProductId, Name = p.ProductName, UnitPrice = p.UnitPrice, UnitsInStock = p.UnitsInStock, UnitsOnOrder = p.UnitsOnOrder })
                    .SingleOrDefaultAsync();


            //送出原生SQL查詢,只包含指定欄位
            ProductViewModel pd = await _context.Products
                    .FromSqlInterpolated($"Select ProductID, ProductName,UnitPrice,UnitsInStock,UnitsOnOrder from dbo.Products where ProductID={id}")
                    .Select(p => new ProductViewModel { Id = p.ProductId, Name = p.ProductName, UnitPrice = p.UnitPrice, UnitsInStock = p.UnitsInStock, UnitsOnOrder = p.UnitsOnOrder })
                    .FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound();
            }

            return View(prod);
        }

        //資料庫交易
        public async Task<IActionResult> DatabaseTransaction()
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Products.Add(new Product { ProductName = "Cola", UnitPrice = 1, UnitsInStock = 15, UnitsOnOrder = 200 });
                    await _context.SaveChangesAsync();

                    Product wine = new Product { ProductName = "Wine", UnitPrice = 20, UnitsInStock = 10, UnitsOnOrder = 50 };
                    _context.Products.Add(wine);
                    await _context.SaveChangesAsync();

                    Product sugar = new Product { ProductName = "Sugar", UnitPrice = 2, UnitsInStock = 50, UnitsOnOrder = 250 };
                    _context.Products.Add(sugar);
                    await _context.SaveChangesAsync();

                    _context.Remove(wine);
                    await _context.SaveChangesAsync();

                    var identityCurrent = await _context.Products.FromSqlRaw("select *  from dbo.Products  where ProductId = IDENT_CURRENT('Products')").FirstOrDefaultAsync();

                    transaction.Commit();
                    _logger.LogWarning("Transaction交易成功!");

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    _logger.LogWarning(ex.ToString());
                }
            }

            return Ok();
        }

        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName");

            return View();
        }

 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,SupplierId,CategoryId,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued")] Product product)
        {
            if (ModelState.IsValid)
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        _context.Products.Add(product);
                        await _context.SaveChangesAsync();

                        //_context.Products.Add(new Product { ProductName = "Wine", UnitPrice = 20, UnitsInStock = 10, UnitsOnOrder = 50 });
                        //await _context.SaveChangesAsync();

                        //可利用SingleOrDefault方法刻意製造Exception
                        //await _context.Products.SingleOrDefaultAsync();

                        transaction.Commit();

                        _logger.LogWarning("Transaction交易成功!");

                        return RedirectToAction(nameof(Index));
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        _logger.LogWarning(ex.ToString());

                        ModelState.AddModelError("TransactionError", ex.ToString());
                    }
                }
            }

            return View(product);
        }

        // GET: ProductsCRUD/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products.FindAsync(id);

            if (products == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", products.CategoryId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName", products.SupplierId);
            return View(products);
        }

        // POST: ProductsCRUD/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,SupplierId,CategoryId,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued")] Product products)
        {
            if (id != products.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        _context.Update(products);
                        await _context.SaveChangesAsync();

                        transaction.Commit();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        transaction.Rollback();

                        if (!ProductsExists(products.ProductId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
 
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", products.CategoryId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName", products.SupplierId);
            return View(products);
        }

        // GET: ProductsCRUD/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.ProductId == id);

            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // POST: ProductsCRUD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var products = await _context.Products.FindAsync(id);

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Products.Remove(products);
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }

    }
}