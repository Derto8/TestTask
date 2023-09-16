using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Task_2.Models;
using Task_2.Requests;

namespace Task_2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var listCountries = await RestCountriesRequests.GetAllCountriesAsync();

            foreach (var countries in listCountries)
            {
                Debug.WriteLine(countries.name.official);
                foreach(var capital in countries.capital)
                {
                    Debug.WriteLine(capital);
                }
            }

            return View(listCountries);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}