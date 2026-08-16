using Microsoft.AspNetCore.Mvc;

namespace Mvc7_ViewComponents.ViewComponents
{
    public class CardListViewComponent : ViewComponent
    {
        public CardListViewComponent()
        {
        }

        public IViewComponentResult Invoke(List<Card> data)
        {
            return View(data);
        }
    }
}
