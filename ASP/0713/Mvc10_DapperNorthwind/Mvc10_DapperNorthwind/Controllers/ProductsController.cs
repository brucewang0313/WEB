using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Mvc10_DapperNorthwind.Models;
using Dapper;

namespace Mvc10_DapperNorthwind.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IConfiguration _config;
        private readonly string _connString;
        public ProductsController(IConfiguration config)
        {
            //_config = config;
            _connString = config.GetConnectionString("NorthwindContext");
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ListAsync()
        {
            // Dapper
            string sql = "select * from products";

            IEnumerable<Product> products = null;

            using (SqlConnection conn = new SqlConnection(_connString))
            {
                products = await conn.QueryAsync<Product>(sql).ConfigureAwait(false);
            }

            return View(products);
        }
    }
}
