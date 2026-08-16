using Microsoft.AspNetCore.Mvc;

namespace EFCore_DbContextConfig.Controllers
{
    public class OptionBuilderController : Controller
    {
        private readonly IConfiguration _config;
        public OptionBuilderController(IConfiguration config)
        {
            _config = config;
        }

        //以DbContextOptionsBuilder建立選項,然後傳入到CardContext
        public async Task<IActionResult> CardListByOptionsBuilder()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CardContext>();
            //設定:1.SQL Server Provider , 2.資料庫連線
            optionsBuilder.UseSqlServer(_config.GetConnectionString("CardSqlServerDB"));

            List<Card> cards = null;
            //將DbContextOptionsBuilder傳入到CardContext建構函式

            using (CardContext ctx = new CardContext(optionsBuilder.Options))
            {
                cards = await ctx.Cards.AsNoTracking().ToListAsync();
            }

            return View(cards);
        }
    }
}
