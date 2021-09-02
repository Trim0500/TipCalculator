using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TipCalculator.Models;

namespace TipCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.mealCost = 0.00;
            ViewBag.tip15 = 0;
            ViewBag.tip20 = 0;
            ViewBag.tip25 = 0;
            return View();
        }

        [HttpPost]
        public IActionResult Index(TipCost model)
        {
            if(ModelState.IsValid)
            {
                ViewBag.tip15 = model.CalcTip15(model.mealCost);
                ViewBag.tip20 = model.CalcTip20(model.mealCost);
                ViewBag.tip25 = model.CalcTip25(model.mealCost);
            }
            else
            {
                ViewBag.tip15 = 0;
                ViewBag.tip20 = 0;
                ViewBag.tip25 = 0;
            }
            return View(model);
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
