using System.Data.SqlClient;
using System.Data;
using System.Diagnostics.Metrics;
using DynamicForm_MVC.Models;
using Dapper;

namespace RegeistrationForm_MVC.Repository
{
    public class FormDataRepository
    {
        public readonly string connectionString;


        public FormDataRepository()
        {

            connectionString = @"Data Source = DESKTOP-Q5KI2MS; Initial Catalog = FormDB; Integrated Security = True";
        }

        public IEnumerable<Country> GetCountries()
        {
            using IDbConnection db = new SqlConnection(connectionString);
            return db.Query<Country>("SELECT * FROM State_M").ToList();
        }

        public IEnumerable<State> GetStatesByCountryId(int countryId)
        {
            using IDbConnection db = new SqlConnection(connectionString);
            return db.Query<State>("SELECT * FROM States WHERE CountryId = @CountryId", new { CountryId = countryId }).ToList();
        }

        public IEnumerable<District> GetDistrictsByStateId(int stateId)
        {
            using IDbConnection db = new SqlConnection(connectionString);
            return db.Query<District>("SELECT * FROM Districts WHERE StateId = @StateId", new { StateId = stateId }).ToList();
        }

        public IEnumerable<City> GetCitiesByDistrictId(int districtId)
        {
            using IDbConnection db = new SqlConnection(connectionString);
            return db.Query<City>("SELECT * FROM Cities WHERE DistrictId = @DistrictId", new { DistrictId = districtId }).ToList();
        }
    }
}
