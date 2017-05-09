using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using sqlbox.Config;
using sqlbox.Interpreter;
using sqlbox.ViewModels;

namespace sqlbox.Controllers
{
    public class QueryController : Controller
    {
        private readonly ConnectionStrings _connectionStrings;

        public QueryController(IOptions<ConnectionStrings> connectionStrings)
        {
            _connectionStrings = connectionStrings.Value;
        }

        public IActionResult Display(string name)
        {
            var query = QuerySelector.GetInstance(name);
            if (query == null)
            {
                return StatusCode(404);
            }

            var model = new StandardQueryViewModel(_connectionStrings, query, HttpContext.Request.Query);
            ViewBag.Title = model.Title;

            return View(model);
        }
    }
}
