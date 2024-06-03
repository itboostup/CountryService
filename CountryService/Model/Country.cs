using System.ComponentModel.DataAnnotations;

namespace CountryService.Model
{
    public class Country
    {
        public long CountryId { get; set; }
        public string CountryName { get; set; } =string.Empty;
        public  string CountryDesc { get; set; } = string.Empty;
        public string CountryCurrency { get; set; } = string.Empty;
        public string CountryRegion { get; set; } = string.Empty;

    }
}
