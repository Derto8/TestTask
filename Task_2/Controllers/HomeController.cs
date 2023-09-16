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

        /// <summary>
        /// Action, возвращает представление Index
        /// </summary>
        /// <param name="cancellationToken">Токен отмены задачи</param>
        /// <returns>Представление Index</returns>
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            return View(await RestCountriesRequests.GetAllCountriesAsync(cancellationToken));
        }

        /// <summary>
        /// Action, к которому обращаются из представления Index для поиска страны
        /// </summary>
        /// <param name="nameCountry">Название страны</param>
        /// <param name="cancellationToken">Токен отмены задачи</param>
        /// <returns>Представление Details</returns>
        [HttpPost]
        public async Task<IActionResult> Index(string nameCountry, CancellationToken cancellationToken)
        {
            var country = await RestCountriesRequests.GetCountryAsync(nameCountry, cancellationToken);
            if (country != null)
                return RedirectToAction("Details", "Home", new { nameCountry = nameCountry});
            return View(await RestCountriesRequests.GetAllCountriesAsync(cancellationToken));
        }

        /// <summary>
        /// Action, возвращает представление Details
        /// </summary>
        /// <param name="nameCountry">Название страны</param>
        /// <param name="cancellationToken">Токен отмены задачи</param>
        /// <returns>Представление Details</returns>
        public async Task<IActionResult> Details(string nameCountry, CancellationToken cancellationToken)
        {
            return View(await RestCountriesRequests.GetCountryAsync(nameCountry, cancellationToken));
        }


        /// <summary>
        /// Вовзращает представление Error
        /// </summary>
        /// <returns>Представление Error</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}