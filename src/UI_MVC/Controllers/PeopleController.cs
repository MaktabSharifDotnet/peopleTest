using Microsoft.AspNetCore.Mvc;
using UI_MVC.Models.DataBase;
using UI_MVC.Models.Entities;

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
        public IActionResult Add() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Person model)
        {
            AppDbContext dbContext = new AppDbContext();
            dbContext.People.Add(model);
            dbContext.SaveChanges();
            return RedirectToAction("index");
            //return View();
        }
        public IActionResult Edit(int id)
        {
            AppDbContext dbContext = new AppDbContext();
            var result=dbContext.People.Find(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Person model)
        {
            AppDbContext dbContext = new AppDbContext();
            var result = dbContext.People.Find(model.Id);
            result.FirstName = model.FirstName;
            result.LastName = model.LastName;
            result.CityName = model.CityName;
            result.PhoneNumber = model.PhoneNumber;
            dbContext.SaveChanges();
            return RedirectToAction("index");
            //return View();
        }
        [HttpPost]
        public IActionResult Delete(int id) 
        {
            AppDbContext dbContext = new AppDbContext();
            var result = dbContext.People.Find(id);
            dbContext.People.Remove(result);
            dbContext.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
