using DynamicForm_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using RegeistrationForm_MVC.Repository;

namespace RegeistrationForm_MVC.Controllers
{
    public class RegeistrationController : Controller
    {
        //private readonly FormDataRepository _repository;

        //public RegeistrationController(FormDataRepository repository)
        //{
        //    _repository = repository;
        //}
        //instance for class which contain crud methods
        FormDataRepository FormData_obj;

        public RegeistrationController()
        {
            FormData_obj = new FormDataRepository();
        }

        public IActionResult RegeisterForm()
        {
            // Retrieve country names from the repository
            IEnumerable<Country> countries = FormData_obj.GetCountries();

            // Pass country names to the view
            return View(countries);

            //var countryNames = FormData_obj.GetCountries();
            //ViewBag.CountryNames = countryNames;
            //return View();
        }

        //[HttpGet("Countries")]
        //public IActionResult GetCountries()
        //{
        //    var countries = FormData_obj.GetCountries();
        //    return Ok(countries);
        //}

         [HttpGet("States")]
        public IActionResult GetStates(int countryId)
        {
            var states = FormData_obj.GetStatesByCountryId(/*countryId*/);
            return Ok(states);
        }

        //[HttpGet("Districts")]
        //public IActionResult GetDistricts(int stateId)
        //{
        //    var districts = _repository.GetDistrictsByStateId(stateId);
        //    return Ok(districts);
        //}

        //[HttpGet("Cities")]
        //public IActionResult GetCities(int districtId)
        //{
        //    var cities = _repository.GetCitiesByDistrictId(districtId);
        //    return Ok(cities);
        //}

    }
}
