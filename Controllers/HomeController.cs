using System.Diagnostics;
using DSD603VM2025.Models;
using DSD603VM2025.Services;
using Microsoft.AspNetCore.Mvc;

namespace DSD603VM2025.Controllers
{
    public class HomeController(ITextFileOperations textFileOperations, IDataSeeder dataSeeder) : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Welcome = "Welcome to the VMS";
            dataSeeder.SeedAsync();

            ViewData["Conditions"] = textFileOperations.LoadConditionsOfAcceptance();

            return View();
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
