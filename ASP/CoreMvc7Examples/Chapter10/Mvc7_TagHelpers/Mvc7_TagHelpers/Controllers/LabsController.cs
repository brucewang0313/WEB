using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;

namespace Mvc7_TagHelpers.Controllers
{

    public class LabsController : Controller
    {
        private IMemoryCache _memoryCache;

        public LabsController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CacheBasic()
        {
            _memoryCache.Set("Email", "dotnetcool@gmail.com");

            var model = _memoryCache.Get<string>("Email");

            return View("CacheBasic", model);
        }
    }

    //public class MyCache : CacheTagHelperBase
    //{
    //    public MyCache(CacheTagHelperMemoryCacheFactory factory)
    //    {

    //    }

    //    public MyDistributedCache(Microsoft.AspNetCore.Mvc.TagHelpers.Cache.IDistributedCacheTagHelperService distributedCacheService)
    //    {

    //    }
    //}
}