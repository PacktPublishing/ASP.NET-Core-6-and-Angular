namespace WorldCitiesAPI.Data
{
    public class CityDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Lat { get; set; }

        public decimal Lon { get; set; }

        public int CountryId { get; set; }

        public string? CountryName { get; set; } = null!;
    }
}
