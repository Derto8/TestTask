using Task_2.Models.ModelRestCountry;

namespace Task_2.Requests
{
    public static class RestCountriesRequests
    {
        public static async Task<List<CountriesViewModel>> GetAllCountriesAsync()
        {
            using(var client = new HttpClient())
            {
                using var request = new HttpRequestMessage(HttpMethod.Get, "https://restcountries.com/v3.1/all");

                using var responce = await client.SendAsync(request);

                var listCountries = await responce.Content.ReadFromJsonAsync<List<CountriesViewModel>>();
                return listCountries;
            }
        }
    }
}
