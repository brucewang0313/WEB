using Microsoft.AspNetCore.Mvc;
using Dapper;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;


namespace EFCore_CodeFirstExistingDB.Controllers
{
    public class DapperController : Controller
    {
        private readonly IConfiguration _config;
        public DapperController(IConfiguration config)
        {
            _config = config;
        }
        public IActionResult Index()
        {
            return View();
        }

        //Dapper查詢強型別
        public async Task<IActionResult> OrdersDetails()
        {
            IEnumerable<OrdersViewModel> ordersVM = null;
            using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("NorthwindConnection")))
            {
                string sql = "SELECT  Orders.OrderID, [Order Details].ProductID, Products.ProductName, [Order Details].UnitPrice, Orders.OrderDate, Orders.ShipAddress, Orders.ShipCity, Orders.ShipCountry FROM Orders INNER JOIN [Order Details] ON Orders.OrderID = [Order Details].OrderID INNER JOIN Products ON [Order Details].ProductID = Products.ProductID";

                ordersVM = await conn.QueryAsync<OrdersViewModel>(sql);
            }

            return View(ordersVM);
        }

        //Dapper查詢dynamic型別
        public IActionResult OrdersDetailsDynamic()
        {
            List<dynamic> ordersList = null;
            using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("NorthwindConnection")))
            {
                string sql = "SELECT  Orders.OrderID, [Order Details].ProductID, Products.ProductName, [Order Details].UnitPrice, Orders.OrderDate, Orders.ShipAddress, Orders.ShipCity, Orders.ShipCountry FROM Orders INNER JOIN [Order Details] ON Orders.OrderID = [Order Details].OrderID INNER JOIN Products ON [Order Details].ProductID = Products.ProductID";

                ordersList = conn.Query(sql).ToList();  //回傳List<dynamic>型別集合
            }

            //1.將List<dynamic>型別集合序列化成JSON文字, 再JSON文字反序列化成List<OrdersViewModel>,完成型別轉換
            List<OrdersViewModel> ordersVM = JsonConvert.DeserializeObject<List<OrdersViewModel>>(JsonConvert.SerializeObject(ordersList));

            //2.將List<dynamic>型別轉換成List<OrdersViewModel>型別
            List<OrdersViewModel> odsVM = new List<OrdersViewModel>();
            foreach (var o in ordersList)
            {
                odsVM.Add(new OrdersViewModel
                { 
                    OrderId = o.OrderID,
                    ProductId = o.ProductID,
                    ProductName = o.ProductName,
                    UnitPrice= o.UnitPrice,
                    OrderDate= o.OrderDate,
                    ShipAddress= o.ShipAddress,
                    ShipCity= o.ShipCity,
                    ShipCountry= o.ShipCountry,
                });
            }

            return View(odsVM);
        }

        //Dapper查詢dynamic型別後, 回傳JSON文字資料
        public IActionResult OrdersDetailsDynamicJson1()
        {
            List<dynamic> ordersList = null;
            using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("NorthwindConnection")))
            {
                string sql = "SELECT  Orders.OrderID, [Order Details].ProductID, Products.ProductName, [Order Details].UnitPrice, Orders.OrderDate, Orders.ShipAddress, Orders.ShipCity, Orders.ShipCountry FROM Orders INNER JOIN [Order Details] ON Orders.OrderID = [Order Details].OrderID INNER JOIN Products ON [Order Details].ProductID = Products.ProductID";

                ordersList = conn.Query(sql).ToList();  //回傳List<dynamic>型別集合
            }

            return Json(ordersList);
        }

        public IActionResult OrdersDetailsDynamicJson2()
        {
            IEnumerable<dynamic> ordersList = null;
            using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("NorthwindConnection")))
            {
                string sql = "SELECT  Orders.OrderID, [Order Details].ProductID, Products.ProductName, [Order Details].UnitPrice, Orders.OrderDate, Orders.ShipAddress, Orders.ShipCity, Orders.ShipCountry FROM Orders INNER JOIN [Order Details] ON Orders.OrderID = [Order Details].OrderID INNER JOIN Products ON [Order Details].ProductID = Products.ProductID";

                ordersList = conn.Query(sql);   //回傳IEnumerable<dynamic>型別集合
            }

            string json = JsonConvert.SerializeObject(ordersList);

            return Content(json, "application/json");
        }
    }
}
