using Microsoft.AspNetCore.Mvc;

namespace Mvc7_ViewComponents.ViewComponents
{
    public class ScoreListViewComponent : ViewComponent
    {

        public ScoreListViewComponent()
        {
            
        }

        //InvokeAsync()和Invoke()方法只能二選一public公開,不能同時存在

        public IViewComponentResult Invoke(List<Student> students)
        {
            return View(students);
        }

        //public IViewComponentResult Invoke(List<Student> students)
        //{
        //    return View(students);
        //}
    }
}