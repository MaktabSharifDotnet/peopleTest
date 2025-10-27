using Microsoft.AspNetCore.Mvc;
using UI_MVC.Models.DataBase;

namespace UI_MVC.Controllers
{
    public class PeopleController : Controller
    {
        public IActionResult Index()
        {
            var dbContext = new AppDbContext();
            var people = dbContext.People.ToList();

            return View(people);
        }
    }
}
