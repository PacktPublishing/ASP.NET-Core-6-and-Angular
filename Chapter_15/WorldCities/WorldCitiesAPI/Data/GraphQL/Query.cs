using Microsoft.EntityFrameworkCore;
using WorldCitiesAPI.Data.Models;

namespace WorldCitiesAPI.Data.GraphQL
{
    public class Query
    {
        /// <summary>
        /// Gets all Cities.
        /// </summary>
        [Serial]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<City> GetCities(
            [Service] ApplicationDbContext context)
            => context.Cities;

        /// <summary>
        /// Gets all Countries.
        /// </summary>
        [Serial]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Country> GetCountries(
            [Service] ApplicationDbContext context)
            => context.Countries;

        /// <summary>
        /// Gets all Cities (with ApiResult and DTO support).
        /// </summary>
        [Serial]
        public async Task<ApiResult<CityDTO>> GetCitiesApiResult(
            [Service] ApplicationDbContext context,
            int pageIndex = 0,
            int pageSize = 10,
            string? sortColumn = null,
            string? sortOrder = null,
            string? filterColumn = null,
            string? filterQuery = null)
        {
            return await ApiResult<CityDTO>.CreateAsync(
                    context.Cities.AsNoTracking()
                        .Select(c => new CityDTO()
                        {
                            Id = c.Id,
                            Name = c.Name,
                            Lat = c.Lat,
                            Lon = c.Lon,
                            CountryId = c.Country!.Id,
                            CountryName = c.Country!.Name
                        }),
                    pageIndex,
                    pageSize,
                    sortColumn,
                    sortOrder,
                    filterColumn,
                    filterQuery);
        }

        /// <summary>
        /// Gets all Countries (with ApiResult and DTO support).
        /// </summary>
        [Serial]
        public async Task<ApiResult<CountryDTO>> GetCountriesApiResult(
            [Service] ApplicationDbContext context,
            int pageIndex = 0,
            int pageSize = 10,
            string? sortColumn = null,
            string? sortOrder = null,
            string? filterColumn = null,
            string? filterQuery = null)
        {
            return await ApiResult<CountryDTO>.CreateAsync(
                    context.Countries.AsNoTracking()
                        // .Include(c => c.Cities),
                        .Select(c => new CountryDTO()
                        {
                            Id = c.Id,
                            Name = c.Name,
                            ISO2 = c.ISO2,
                            ISO3 = c.ISO3,
                            TotCities = c.Cities!.Count
                        }),
                    pageIndex,
                    pageSize,
                    sortColumn,
                    sortOrder,
                    filterColumn,
                    filterQuery);
        }
    }
}
