using Microsoft.AspNetCore.Mvc;
using Mvc10_Razor.Models;
using Mvc10_Razor.Services;

namespace Mvc10_Razor.Controllers
{
    public class PartialViewController : Controller
    {
        public List<Card> cards;

        private readonly CardContext _context;

        public PartialViewController(CardContext context)
        {
            _context = context;
            cards = new List<Card>()
            {
                new Card { Name = "Elon Musk", Brief="特斯拉創辦人 伊隆·馬斯克", Photo="ElonMusk.jpg", WikiUrl="https://goo.gl/46xeXx" },
                new Card { Name = "Mark Zuckerberg", Brief="Facebook創辦人 馬克·祖伯克", Photo="MarkZuckerberg.jpg", WikiUrl="https://goo.gl/BktGGA" },
                new Card { Name = "Steve Jobs", Brief="蘋果創辦人 史提夫·賈伯斯", Photo="SteveJobs.jpg", WikiUrl="https://goo.gl/nAiX0y" },
                new Card { Name = "ViviChu", Brief="帝國元帥  豬想飛", Photo="Vader.jpg", WikiUrl="http://bit.ly/3F5xw2w" },
                new Card { Name = "Darth Mual", Brief="星際大戰 達斯摩", Photo="DarthMual.jpg", WikiUrl="https://goo.gl/5obLhX"},
                new Card { Name = "White Twilek", Brief="星際大戰 女絕地武士Twilek", Photo="WhiteTwilek.jpg", WikiUrl="https://goo.gl/reKzAu" },
                new Card { Name = "Obiwan", Brief="星際大戰 歐比旺Obiwan", Photo="Obiwan.jpg", WikiUrl="http://bit.ly/33gxdgt" },
                new Card { Name = "ViviChu", Brief="豬國組長 True祥薇", Photo="Merkel.jpg", WikiUrl="http://bit.ly/33huSlv" }
            };
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SimpleCard()
        {
            return View();
        }

        public IActionResult CardList()
        {

            ProductService productService = new ProductService();
            var cardsData = productService.GetCardsData();
            return View(cards);
        }

        public async Task<IActionResult> CardListDB()
        {
            return View(await _context.Card.ToListAsync());
        }
    }
}
