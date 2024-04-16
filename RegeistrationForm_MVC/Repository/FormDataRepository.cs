using System.Data.SqlClient;
using System.Data;
using System.Diagnostics.Metrics;
using DynamicForm_MVC.Models;
using Dapper;
using System.Net.Http.Headers;
using RegeistrationForm_MVC.Models;


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
            return db.Query<Country>("SELECT * FROM Country_M").ToList();
        }

        public IEnumerable<State> GetStatesByCountryId(int countryId)
        {
            using IDbConnection db = new SqlConnection(connectionString);
            //return db.Query<State>("SELECT * FROM States").ToList();

            return db.Query<State>("SELECT * FROM state_M WHERE Countries_M_CountryId = @CountryId", new { CountryId = countryId }).ToList();
        }

        public IEnumerable<District> GetDistrictsByStateId(int stateId)
        {
            using IDbConnection db = new SqlConnection(connectionString);
            return db.Query<District>("SELECT * FROM district WHERE States_M_StateId = @StateId", new { StateId = stateId }).ToList();
        }

        public IEnumerable<City> GetCitiesByDistrictId(int districtId)
        {
            using IDbConnection db = new SqlConnection(connectionString);
            return db.Query<City>("SELECT * FROM city WHERE Districts_M_DistrictId = @DistrictId", new { DistrictId = districtId }).ToList();
        }

        public IEnumerable<UnivericityModel> GetUniversity(int countryId)
        {
            using IDbConnection db = new SqlConnection(connectionString);
            return db.Query<UnivericityModel>("select * from univerisity_M where Country_id = @Country_id", new { Country_id = countryId }).ToList();
        }
        public /*IEnumerable<UnivericityModel>*/void  InsertRegeister(RegeisterModel RegeisterDetails)
        {
            using IDbConnection db = new SqlConnection(connectionString);


            SqlConnection connectionObject = new SqlConnection(connectionString);

            connectionObject.Open();
            //connectionObject.Execute($"exec InsertPersonalBio '{bio.Name}', '{bio.LastName}',{bio.Age},'{bio.Address}' ");

            connectionObject.Execute($"insert into Regeister values( '{RegeisterDetails.RegeisterName}', '{RegeisterDetails.Country}','{RegeisterDetails.State}','{RegeisterDetails.District}','{RegeisterDetails.City}','{RegeisterDetails.University}')");

            connectionObject.Close();


            //return db.Query<UnivericityModel>("select * from univerisity_M ").ToList();
        }

        public IEnumerable<RegeisterModel1> ReturnAllRegeistration(/*int countryId*/)
        {
            using IDbConnection db = new SqlConnection(connectionString);
            return db.Query<RegeisterModel1>("select * from Regeister").ToList();
        }

    }
}
