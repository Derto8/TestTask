using System.Net;
using Task_2.Models.ModelRestCountry;

namespace Task_2.Requests
{
    public static class RestCountriesRequests
    {
        /// <summary>
        /// Запрос на получение всех данных стран с API
        /// </summary>
        /// <param name="cancellationToken">Токен отмены задачи</param>
        /// <returns>Список со всеми данными стран</returns>
        public static async Task<List<CountriesViewModel>> GetAllCountriesAsync(CancellationToken cancellationToken)
        {
            using(var client = new HttpClient())
            {
                using var request = new HttpRequestMessage(HttpMethod.Get, "https://restcountries.com/v3.1/all");

                using var responce = await client.SendAsync(request, cancellationToken);

                if (responce.StatusCode == HttpStatusCode.NotFound)
                    return null;

                var listCountries = await responce.Content.ReadFromJsonAsync<List<CountriesViewModel>>();

                return listCountries.OrderBy(x => x.Name.Official).ToList();
            }
        }

        /// <summary>
        /// Запрос на получение данных одной страны с API
        /// </summary>
        /// <param name="nameCountry">Название страны</param>
        /// <param name="cancellationToken">Токен отмены задачи</param>
        /// <returns>Возвращает одну страну по её названию</returns>
        public static async Task<List<CountriesViewModel>> GetCountryAsync(string nameCountry, CancellationToken cancellationToken)
        {
            using (var client = new HttpClient())
            {
                using var request = new HttpRequestMessage(HttpMethod.Get, $"https://restcountries.com/v3.1/name/{nameCountry}");

                using var responce = await client.SendAsync(request, cancellationToken);

                if (responce.StatusCode == HttpStatusCode.NotFound)
                    return null;

                var country = await responce.Content.ReadFromJsonAsync<List<CountriesViewModel>>();

                return country;
            }
        }
    }
}
