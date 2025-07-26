using ServiceContracts.DTO;

namespace ServiceContracts
{
    /// <summary>
    /// Represents the business logic for manipulating Country entity
    /// </summary>
    public interface ICountriesService
    {
        /// <summary>
        /// Adds a country object to the list of countries
        /// </summary>
        /// <param name="countryAddRequest">Country object to add</param>
        /// <returns>Return the country object after adding it (including newsly generated country id)</returns>
        CountryResponse AddCountry(CountryAddRequest? countryAddRequest);

        /// <summary>
        /// Return all countries from the list
        /// </summary>
        /// <returns>Return all countries from the list as List<CountryResponse></returns>
        List<CountryResponse> GetAllCountries();

        /// <summary>
        /// Return a country object based on the given country id
        /// </summary>
        /// <param name="countryID">Country (guid) to search</param>
        /// <returns>Matching country as CountryResponse Object</returns>
        CountryResponse? GetCountryByCountryID(Guid? countryID);
    }
}
