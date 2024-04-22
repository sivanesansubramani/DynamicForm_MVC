using DynamicForm_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using RegeistrationForm_MVC.Models;
using RegeistrationForm_MVC.Repository;
using System;

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

        [HttpGet("Countries")]
        public IActionResult GetCountries()
        {
            var countries = FormData_obj.GetCountries();
            return Ok(countries);
        }

         [HttpGet("States")]
        public IActionResult GetStates(int countryId)
        {
            var states = FormData_obj.GetStatesByCountryId(countryId);
            return Ok(states);
        }

        [HttpGet("Districts")]
        public IActionResult GetDistricts(int stateId)
        {
            var districts = FormData_obj.GetDistrictsByStateId(stateId);
            return Ok(districts);
        }

        [HttpGet("cities")]
        public IActionResult GetCities(int districtid)
        {
            var cities = FormData_obj.GetCitiesByDistrictId(districtid);
            return Ok(cities);
        }
        [HttpGet("university")]
        public IActionResult Getuniversity(int countryId)
        {
            var cities = FormData_obj.GetUniversity(countryId);
            return Ok(cities);
        }

        //[HttpPost("RegeisterFormDetails")]
        public ActionResult RegeisterFormDetails(RegeisterModel RegeisterDetails)
        {

            // RegeisterModel RegeisterDetails = new RegeisterModel();

            //RegeisterDetails.RegeisterId = firstName;
            // RegeisterDetails.RegeisterName = firstName;
            // RegeisterDetails.Country = firstName;
            // RegeisterDetails.State = firstName;
            // RegeisterDetails.District = firstName;
            // RegeisterDetails.City = firstName;
            // RegeisterDetails.University = firstName;


            if (RegeisterDetails.RegeisterName != null)
            {
                FormData_obj.InsertRegeister(RegeisterDetails);
                //Persons.Add(p);
            }

            //var RegeisterDetails1 = FormData_obj.ReturnAllRegeistration();

            return View(RegeisterForm);
        }

    }
}
