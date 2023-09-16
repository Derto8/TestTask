namespace Task_2.Models.ModelRestCountry
{
    /// <summary>
    /// Основная модель для получения данных из json
    /// </summary>
    public class CountriesViewModel
    {
        public Name Name { get; set; }
        public string[] Capital { get; set; }
        public string Region { get; set; }
        public Languages Languages { get; set; }
    }
}
