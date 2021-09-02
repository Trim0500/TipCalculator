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

        [HttpGet] //Use a tag to mapp the call to the get protocol
        public IActionResult Index()
        {
            //Set all the fields for the index to 0
            ViewBag.mealCost = 0.00;
            ViewBag.tip15 = 0;
            ViewBag.tip20 = 0;
            ViewBag.tip25 = 0;
            return View();
        }

        [HttpPost] //Use a tag top map the submit button post call to this function
        public IActionResult Index(TipCost model)
        {
            if(ModelState.IsValid) //Check if the model data is valid
            {
                ViewBag.tip15 = model.CalcTip15(model.mealCost); //Set the 15% tip total to the model class' function
                ViewBag.tip20 = model.CalcTip20(model.mealCost); //Set the 20% tip total to the model class' function
                ViewBag.tip25 = model.CalcTip25(model.mealCost); //Set the 25% tip total to the model class' function
            }
            else //If the model is invalid, set everything to 0
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
