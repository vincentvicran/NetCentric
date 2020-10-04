using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using simplenetcoreapp.Models;
using Microsoft.AspNetCore.Localization;

namespace simplenetcoreapp.Controllers
{
    public class PDEdit : Controller
    {
        private readonly ILogger<PDEdit> _logger;

        public PDEdit(ILogger<PDEdit> logger)
        {
            _logger = logger;

            //inheritence from PersonalDetails to DoctorProfile
           

        }



        public IActionResult PDEditor()
        {
            return View(PersonMemory.GetPersons());
        }


        public IActionResult PersonList()
        {
            return View("", PersonMemory.GetPersons());
        }


// GET: PDEdit
public ActionResult Index()
        {
            return View();
        }

        

        // GET: PDEdit/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PDEdit/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PDEdit/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PDEdit/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PDEdit/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PDEdit/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PDEdit/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public IActionResult PersonalDetails(int personDetailsID)
        {
            PersonalDetails pdetail = new PersonalDetails();
            pdetail = PersonMemory.GetPersons().Where(x => x.PersonalDetailsID == personDetailsID).FirstOrDefault();
            return View("PersonalDetails", pdetail);
        }

        public IActionResult PersonalDetailsEdit(int personDetailsID)
        {
            PersonalDetails pdetail = new PersonalDetails();
            pdetail = PersonMemory.GetPersons().Where(x => x.PersonalDetailsID == personDetailsID).FirstOrDefault();
            return View( pdetail);
        }

        [HttpPost]
        public IActionResult PersonalDetailsEdit(PersonalDetails pd)
        {
            var personInList = PersonMemory.GetPersons().Where(x => x.PersonalDetailsID == pd.PersonalDetailsID).FirstOrDefault();
            personInList.FirstName = pd.FirstName;
            personInList.Address = pd.Address;
            personInList.Age = pd.Age;
            personInList.Occupation = pd.Occupation;

            return RedirectToAction("PDEditor");
        }


        public IActionResult CreatePersonDetail()
        {
            PersonalDetails pd = new PersonalDetails();
            return View(pd);
        }

        [HttpPost]
        public IActionResult CreatePersonDetail(PersonalDetails pd)
        {
            var personDetailList = PersonMemory.GetPersons();
            int currentPersonCount = personDetailList.Count;
            pd.PersonalDetailsID = ++currentPersonCount;
            personDetailList.Add(pd);
            return RedirectToAction("PDEditor");
        }

    }
}
