using DropDown.Models;
using Dropdown_Tp5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Dropdown_Tp5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public ApplicationDbContext dbContext { get; }

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext application)
        {
            _logger = logger;
            dbContext = application;
        }

        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetCountries()
        {
            var countries = dbContext.countries.ToList();
            return Json(countries);
        }
        public JsonResult GetStates(int id)
        {
            var states = dbContext.states.Where(e => e.Country.Id == id);
            return Json(states);
        }
        public JsonResult GetCities(int id)
        {
            var cities = dbContext.cities.Where(e => e.State.Id == id);
            return Json(cities);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
