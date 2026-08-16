using Microsoft.AspNetCore.Mvc;
using Mvc10_Fundamentals.Models;
using System.Diagnostics;

namespace Mvc10_Fundamentals.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public HomeController(ILogger<HomeController> logger)//為了相依性
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        EventId evenId = new EventId(1234, "我的紀錄資訊");
        _logger.LogWarning(evenId, "Home/Index被呼叫!");
        _logger.LogWarning(1234, "Logging - Home/Index被呼叫!");
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
