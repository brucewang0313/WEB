using Microsoft.AspNetCore.Mvc;

namespace Mvc7_Resume.Controllers
{
    public class MixedController : Controller
    {
        public IActionResult Index()
        {
            //利用MixedViewModel傳遞多個Model到View

            //1.設定資料方式一
            List<Product> products = new List<Product>() 
            { 
                new Product { Id=1, Name="CPU", Price=10000 },
                new Product { Id=2, Name="SSD", Price=3000 },
            };

            List<Employee> employees = new List<Employee>()
            {
                new Employee { Id=1, Name="Kevin", Email="kevin@gmail.com" },
                new Employee { Id=2, Name="Mary", Email="mary@gmail.com" },
            };

            MixedViewModel mixedVM = new MixedViewModel
            {
                Products = products,
                Employees = employees,
            };


            //2.設定資料方式二
            MixedViewModel mixedVMSuper = new MixedViewModel
            {
                Products = new List<Product>()
                            {
                                new Product { Id=1, Name="CPU", Price=10000 },
                                new Product { Id=2, Name="SSD", Price=3000 },
                            },
                Employees = new List<Employee>()
                            {
                                new Employee { Id=1, Name="Kevin", Email="kevin@gmail.com" },
                                new Employee { Id=2, Name="Mary", Email="mary@gmail.com" }
                            }
            };


            return View(mixedVM);
        }
    }
}
