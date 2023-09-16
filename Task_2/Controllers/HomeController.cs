using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Task_2.Models;
using Task_2.Models.ModelRestCountry;
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

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            return View(await RestCountriesRequests.GetAllCountriesAsync(cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> Index(string nameCountry, CancellationToken cancellationToken)
        {
            var country = await RestCountriesRequests.GetCountryAsync(nameCountry, cancellationToken);
            if (country != null)
                return RedirectToAction("Details", "Home", new { nameCountry = nameCountry});
            return View(await RestCountriesRequests.GetAllCountriesAsync(cancellationToken));
        }

        public async Task<IActionResult> Details(string nameCountry, CancellationToken cancellationToken)
        {
            return View(await RestCountriesRequests.GetCountryAsync(nameCountry, cancellationToken));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}