using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using FirstMVCApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;

namespace TestingNetNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IConfiguration _iConfig;
        private IWebHostEnvironment _env;
        public HomeController(ILogger<HomeController> logger, IConfiguration iConfig, IWebHostEnvironment env)
        {
            _logger = logger;
            _iConfig = iConfig;
            _env = env;


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
                if (Request.Form.Files["profile-image"] != null)
                {
                    //saving
                    if (Request.Form.Files["profile-image"].Length > 10 * 1024 * 1024)
                    {

                        personDetail.ErrorMsg = "File is not within size limit of 10MB.";
                        return View(personDetail);
                    }
                    string pathToFolder = Path.Combine(_env.WebRootPath, "UploadedFiles", Request.Form.Files["profile-image"].FileName);
                    var fileStream = new FileStream(pathToFolder, FileMode.Create);
                    Request.Form.Files["profile-image"].CopyTo(fileStream);
                    personDetail.ImageLocation = "UploadedFiles" + Request.Form.Files["profile-image"].FileName;
                }

                var personInList = PersonMemory.GetPersons().Where(x => x.PersonalDetailId == personDetail.PersonalDetailId).FirstOrDefault();

                personInList.FirstName = personDetail.FirstName;
                personInList.Occupation = personDetail.Occupation;
                personInList.Age = personDetail.Age;
                personInList.Address = personDetail.Address;
                personInList.ImageLocation = personDetail.ImageLocation;
            
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
            if (ModelState.IsValid)
            {
                if (Request.Form.Files["profile-image"]!=null)
                {
                    //saving
                    if(Request.Form.Files["profile-image"].Length>10*1024*1024)
                    {
                        
                        person.ErrorMsg = "File is not within size limit of 10MB.";
                        return View(person);
                    }
                    string pathToFolder = Path.Combine(_env.WebRootPath, "UploadedFiles", Request.Form.Files["profile-image"].FileName);
                    var fileStream = new FileStream(pathToFolder, FileMode.Create);
                    Request.Form.Files["profile-image"].CopyTo(fileStream);
                    person.ImageLocation = pathToFolder;
                    /*person.ImageLocation = "UploadedFiles" + Request.Form.Files["profile-image"].FileName;*/
                }
                var personDetailList = PersonMemory.GetPersons();
                int personsCount = personDetailList.Count;
                person.PersonalDetailId = ++personsCount;

                personDetailList.Add(person);
                return RedirectToAction("Persons");
            }

            else
                return View(person);
        }

        public IActionResult DeletePerson(int personDetailId)
        {
            var person = PersonMemory.GetPersons().Where(person => person.PersonalDetailId == personDetailId ).FirstOrDefault();
            PersonMemory.GetPersons().Remove(person);

            return RedirectToAction("Persons");
        }

        //ExceptionHandling
        #region CatchAndTry

        public IActionResult GetSumOfNumbers(PersonalDetail pd)
        {
            Int16 firstNumber;
            Int16 secondNumber;
            Int16 sumOfNumbers = 0;
            Int16 divisor = 1;
            Int16 dividend = 0;
            string stringNumber = "125a";
            //PersonalDetail pd;
            //max 32767
            try
            {
                List<Int16> integerList = new List<Int16>();
                integerList.Add(1234);

                firstNumber = Convert.ToInt16(1234);
                secondNumber = integerList[0];
                sumOfNumbers = Convert.ToInt16(firstNumber + secondNumber);
                dividend = Convert.ToInt16(firstNumber / divisor);
                divisor = Convert.ToInt16(stringNumber);
                string name = pd.Address;
            }
            catch (IndexOutOfRangeException ex)
            {
                return Json(new { ExceptionMessage = ex.Message });
            }
            catch (NullReferenceException ex)
            {
                return Json(new { ExceptionMessage = ex.Message });
            }
            catch (OutOfMemoryException ex)
            {
                //we have 4 gb
                //current process consuming 2 gb
                //clean

                return Json(new { ExceptionMessage = ex.Message });
            }

            catch (DivideByZeroException ex)
            {
                return Json(new { ExceptionMessage = ex.Message });
            }
            catch (FormatException ex)
            {
                return Json(new { ExceptionMessage = "Please enter valid age !!" });
            }
            catch (InvalidCastException ex)
            {
                return Json(new { ExceptionMessage = ex.Message });
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return Json(new { ExceptionMessage = ex.Message });
            }
            catch (Exception ex)
            {
                return Json(new { ExceptionMessage = ex.Message });

            }
            finally
            {
                sumOfNumbers += 10;
            }

            return Json(new { sum = sumOfNumbers });
        }
        public ActionResult CheckPerformanceOfTryCatch()
        {
            TimeSpan a;
            TimeSpan b;
            Stopwatch w = new Stopwatch();
            double d = 0;

            w.Start();

            for (int i = 0; i < 1000; i++)
            {
                try
                {
                    d = Math.Sin(Convert.ToInt32("abcd"));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            w.Stop();
            a = w.Elapsed;
            w.Reset();
            w.Start();

            for (int i = 0; i < 10000000; i++)
            {
                d = Math.Sin(1);
            }

            w.Stop();
            b = w.Elapsed;
            return Json(new { withtrycatch = a, withouttrycatch = b });
        }
        #endregion


    }
}
