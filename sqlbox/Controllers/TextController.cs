using Microsoft.AspNetCore.Mvc;

namespace sqlbox.Controllers
{
    public class TextController : Controller
    {
        public IActionResult Display(string name)
        {
            return View(name);
        }
    }
}
