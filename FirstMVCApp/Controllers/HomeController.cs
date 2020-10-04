using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FirstMVCApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TestingNetNetCore.Models;

namespace TestingNetNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IConfiguration _iConfig;
        public HomeController(ILogger<HomeController> logger, IConfiguration iConfig)
        {
            _logger = logger;
            _iConfig = iConfig;



            //add items to list
            //hari as a doctor
            //inherit from profiledetail

        }

        public IActionResult Index()
        {
            ViewBag.MyKey = _iConfig["MyKey"];
            return View();

        }
        public IActionResult AboutMe()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Persons()
        {
            return View(PersonMemory.GetPersons());

        }
        public IActionResult PersonalDetails(int personDetailId)
        {
            PersonalDetail pdetail = new PersonalDetail();
            pdetail = PersonMemory.GetPersons().Where(x => x.PersonalDetailId == personDetailId).FirstOrDefault();

            return View(pdetail);
        }

        public IActionResult EditPersonalDetail(int personDetailId)
        {
            PersonalDetail pdetail = new PersonalDetail();
            pdetail = PersonMemory.GetPersons().Where(x => x.PersonalDetailId == personDetailId).FirstOrDefault();
            


            return View(pdetail);
        }


        [HttpPost]
        public IActionResult EditPersonalDetail(PersonalDetail personDetail)
        {
            if(ModelState.IsValid) { 
            
            var personInList = PersonMemory.GetPersons().Where(x => x.PersonalDetailId == personDetail.PersonalDetailId).FirstOrDefault();

            personInList.FirstName = personDetail.FirstName;
            personInList.Occupation = personDetail.Occupation;
            personInList.Age = personDetail.Age;
            personInList.Address = personDetail.Address;
            
            return RedirectToAction("Persons");
            }
            else
            {
                return View(personDetail);
            }
        }

        public IActionResult CreatePerson()
        {
            PersonalDetail person = new PersonalDetail();

            return View(person);
        }

        [HttpPost]
        public IActionResult CreatePerson(PersonalDetail person)
        {
            var personDetailList = PersonMemory.GetPersons();
            int personsCount = personDetailList.Count;
            person.PersonalDetailId = ++personsCount;

            personDetailList.Add(person);

            return RedirectToAction("Persons");
        }

        public IActionResult DeletePerson(int personDetailId)
        {
            var person = PersonMemory.GetPersons().Where(person => person.PersonalDetailId == personDetailId ).FirstOrDefault();
            PersonMemory.GetPersons().Remove(person);

            return RedirectToAction("Persons");
        }


    }
}
