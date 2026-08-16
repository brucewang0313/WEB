using Microsoft.AspNetCore.Mvc;

namespace EFCore_DbContextConfig.Controllers
{
    public class CardsController : Controller
    {
        private readonly CardContext _context;
        private readonly IConfiguration _config;

        //1.在Controller建構函式用DI注入CardContext實例:
        //使用此方式需在DI Container註冊CardContext服務時,
        //以DBContextOptions指定Provider&資料庫連線,
        public CardsController(CardContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<IActionResult> CardListByDI()
        {
            List<Card> cards = await _context.Cards.AsNoTracking().ToListAsync();

            return View(cards);
        }

        //2.透過IServiceProvider介面的GetService()或GetRequiredService()方法
        public async Task<IActionResult> CardContextByIServiceProvider([FromServices] IServiceProvider sp)
        {
            var _context = sp.GetService<CardContext>();
            //var _context = sp.GetRequiredService<CardContext>();

            List<Card> cards = await _context.Cards.AsNoTracking().ToListAsync();

            return View(cards);
        }

        //直接初始化CardContext類別
        public async Task<IActionResult> DirectNewCardContext()
        {
            //1.new CardContext()時未傳入資料庫連線字串

            List<Card> cards = null;
            using (CardContext _context = new CardContext())
            {
                cards = await _context.Cards.AsNoTracking().ToListAsync();
            }

            //2.new CardContext()時傳入資料庫連線字串
            List<Card> cardList = null;
            using (CardContext _context = new CardContext(@"Server=(localdb)\mssqllocaldb;Database=CardSqlServerDB;Trusted_Connection=True;MultipleActiveResultSets=true"))
            {
                cardList = await _context.Cards.AsNoTracking().ToListAsync();
            }

            return View(cards);
        }

        //以DbContextOptionsBuilder建立選項,然後傳入到CardContext
        public async Task<IActionResult> CardListByOptionsBuilder()
        {
            //1.設定:SQL Server Provider & 資料庫連線
            var optionsBuilder = new DbContextOptionsBuilder<CardContext>();
            optionsBuilder.UseSqlServer(_config.GetConnectionString("CardSqlServerDB"));

            List<Card> cards = null;

            //2.將DbContextOptionsBuilder傳入到CardContext建構函式
            using (CardContext ctx = new CardContext(optionsBuilder.Options))
            {
                cards = await ctx.Cards.AsNoTracking().ToListAsync();
            }

            return View(cards);
        }

        //在DI Container註冊CardContext服務時,但不需用DbContextOptions指定Provider&資料庫連線,
        //而是在DbContext的OnConfiguring()方法中,用DbContextOptionsBuilder指定Provider&資料庫連線
        //透過[FromService]在方法層級注入CardContext實例
        public async Task<IActionResult> CardListByOnConfiguring([FromServices] CardContext ctx)
        {
            List<Card> cards = await ctx.Cards.AsNoTracking().ToListAsync();

            return View(cards);
        }

        //在DI Container註冊CardContext服務時,需用DBContextOptions指定Provider&資料庫連線,才能用此方式注入
        //透過[FromService]在方法層級注入IServiceProvider實例
        public IActionResult GetIConfigurationByIServiceProvider([FromServices]IServiceProvider sp)
        {
            var configuration = sp.GetService<IConfiguration>();

            var config = sp.GetRequiredService<IConfiguration>();

            string conn = configuration.GetConnectionString("CardSqlServerDB");

            ViewData["Conn"] = conn;

            return View();
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.Cards.ToListAsync());
        }
    }
}