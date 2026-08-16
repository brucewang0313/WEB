using Microsoft.AspNetCore.Mvc;

namespace Mvc7_ViewComponents.ViewComponents
{
    [ViewComponent(Name ="HeroList")]
    public class Heros : ViewComponent
    {
        public IViewComponentResult Invoke(List<Card> data)
        {
            return View(data);
        }
    }
}
