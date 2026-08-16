using Microsoft.AspNetCore.Mvc;

namespace Mvc7_FirstMVC.Controllers
{
    public class LabsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult ArrayWithNamedType()
        {
            //Friend型別陣列
            Friend[] friends = new Friend[]
            {
                new Friend { Name = "Rose", Country = "USA" },
                new Friend { Name="David", Country="Japan" },
                new Friend { Name="John", Country="USA" },
                new Friend { Name="Bob", Country="Italy" },
                new Friend { Name="Johnson", Country="Tailand" },
                new Friend { Name="Cindy", Country="Japan" },
                new Friend { Name="Lucy", Country="Korea" },
                new Friend { Name="Angal", Country="Italy" },
                new Friend { Name="Maya", Country="Tailand" },
                new Friend { Name="Max", Country="Korea" }
            };

            return View(friends);
        }

        public ActionResult ArrayWithNamedTypeToList()
        {
            //Friend型別陣列
            Friend[] friends = new Friend[]
            {
                new Friend { Name = "Rose", Country = "USA" },
                new Friend { Name="David", Country="Japan" },
                new Friend { Name="John", Country="USA" },
                new Friend { Name="Bob", Country="Italy" },
                new Friend { Name="Johnson", Country="Tailand" },
                new Friend { Name="Cindy", Country="Japan" },
                new Friend { Name="Lucy", Country="Korea" },
                new Friend { Name="Angal", Country="Italy" },
                new Friend { Name="Maya", Country="Tailand" },
                new Friend { Name="Max", Country="Korea" }
            };

            var Query = from f in friends
                        where f.Country == "Italy" || f.Country == "Japan"
                        orderby f.Country, f.Name
                        select f;

            var methodQuery = friends.Where(f => f.Country == "Italy" || f.Country == "Japan")
                                     .OrderByDescending(f => f.Country)
                                     .ThenBy(f => f.Name)
                                     .Select(f => f);

            var result = Query.ToList();
            return View(Query);
        }

        public ActionResult ArrayWithAnonymousType()
        {
            //1. var為隱含型別區域變數 (implicitly typed local variable)
            //2. Products為隱含型別陣列(implicitly typed array)
            //3. 陣列成員為匿名型別物件(Anonymous Typed Object)
            var Products = new[] {
                new { ID = 1, Name = "CPU", UnitPrice = 12000 },
                new { ID = 2, Name = "LCD", UnitPrice = 5000 },
                new { ID = 3, Name = "Mouse", UnitPrice = 600 },
                new { ID = 4, Name = "Keyboard", UnitPrice = 1200 },
                new { ID = 5, Name = "SSD", UnitPrice = 6800 }
            };


            //在select時初始匿名型別物件
            var productQuery = from p in Products
                               where p.UnitPrice > 5000
                               select p;

            //轉換成LIST集合,保存在記憶體中
            var productList = productQuery.ToList();

            //在select時初始匿名型別物件時,指定新的Properties屬性名稱
            var Query = from p in Products
                        where p.UnitPrice > 5000
                        select new { 產品名稱 = p.Name, 單價 = p.UnitPrice };

            //以價錢降冪排序,取前Top 3紀錄
            var top3Products = Products.OrderByDescending(p => p.UnitPrice)
                                       .ThenBy(p => p.Name)
                                       .Take(3)
                                       .Select(p => new { p.Name, p.UnitPrice });


            return View(productQuery);
        }

        public ActionResult DynamicList()
        {
            List<dynamic> products = new List<dynamic>
            {
                new { ID = 1, Name = "CPU", UnitPrice = 12000 },
                new { ID = 2, Name = "LCD", UnitPrice = 5000 },
                new { ID = 3, Name = "Mouse", UnitPrice = 600 },
                new { ID = 4, Name = "Keyboard", UnitPrice = 1200 },
                new { ID = 5, Name = "SSD", UnitPrice = 6800 }
            };

            var Query = from p in products
                        select p;

            return View(Query);

        }
    }
}
