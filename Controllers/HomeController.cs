using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using simplenetcoreapp.Models;

namespace simplenetcoreapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private List<PersonalDetails> detailList = new List<PersonalDetails>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

            //inheritence from PersonalDetails to DoctorProfile
            DoctorProfile Vicran = new DoctorProfile()
            {
                FirstName = "Vikrant Shrestha",
                Address = "Kathmnandu",
                Age = 21,
                Occupation = "Doctor",
                //DoctorProfile specific property
                HospitalClinic = "Grande Hospital",
                Qualification = "MD",
                Speciality = "NeuroSurgeon"
            };
            detailList.Add(Vicran);


            //inheritence from PersonalDetails to TeacherProfile
            TeacherProfile Sinke = new TeacherProfile()
            {
                FirstName = "Aman Butthe",
                Address = "Darjeeling",
                Age = 20,
                Occupation = "Teacher",
                //TeacherProfile specific property
                Qualification = "B.Ed.",
                Institute = "JMC",
                AssociatedSubjects = "Mathematics"
            };
            detailList.Add(Sinke);


            //inheritence from PersonalDetails to StudentProfile
            StudentProfile Sallu = new StudentProfile()
            {
                FirstName = "Salina Awal",
                Address = "Bhaktapur",
                Age = 23,
                Occupation = "Student",
                //StudentProfile specific property
                Faculty = "Architecture",
                College_School = "Pulchowk",
                Rollno = 15162
            };
            detailList.Add(Sallu);

        }

        public IActionResult Persons()
        {
            return View(detailList);
        }

        public IActionResult Index()
        {

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

       /* public IActionResult PersonalDetails(string person)
        {
            PersonalDetails Vicran = new PersonalDetails();
            Vicran.FirstName = "Vikrant Shrestha";
            Vicran.Address = "Kathmnandu";
            Vicran.Age = 21;
            Vicran.Occupation = "Student";
            Vicran.Qualification = "+2";
            Vicran.OfficeName = "PlankSoft";

            PersonalDetails Sinke = new PersonalDetails();
            Sinke.FirstName = "Sinbad Kesari";
            Sinke.Address = "Bhaktpaur";
            Sinke.Age = 21;
            Sinke.Occupation = "Student";
            Sinke.Qualification = "+2";
            Sinke.OfficeName = "MagiShift";

            PersonalDetails saurav = new PersonalDetails();
            saurav.FirstName = "Vikrant Shrestha";
            saurav.Address = "Kathmnandu";
            saurav.Age = 21;
            saurav.Occupation = "Student";
            saurav.Qualification = "+2";
            saurav.OfficeName = "PlankSoft";

            PersonalDetails adit = new PersonalDetails();
            adit.FirstName = "Sinbad Kesari";
            adit.Address = "Bhaktpaur";
            adit.Age = 21;
            adit.Occupation = "Student";
            adit.Qualification = "+2";
            adit.OfficeName = "MagiShift";

            PersonalDetails rozeel = new PersonalDetails();
            rozeel.FirstName = "Vikrant Shrestha";
            rozeel.Address = "Kathmnandu";
            rozeel.Age = 21;
            rozeel.Occupation = "Student";
            rozeel.Qualification = "+2";
            rozeel.OfficeName = "PlankSoft";

            PersonalDetails kusi = new PersonalDetails();
            kusi.FirstName = "Sinbad Kesari";
            kusi.Address = "Bhaktpaur";
            kusi.Age = 21;
            kusi.Occupation = "Student";
            kusi.Qualification = "+2";
            kusi.OfficeName = "MagiShift";

            PersonalDetails personDetails = new PersonalDetails();
            if (person == "Vikrant Shrestha")
            {
                personDetails = Vicran;
            }
            else if (person == "Sinbad Kesari")
            {
                personDetails = Sinke;
            }

            return View("PersonalDetails", personDetails);
        }*/

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult PersonalDetails(int PersonalDetailsID)
        {
            PersonalDetails pdetail = new PersonalDetails();
            pdetail = detailList.Where(x=>x.PersonalDetailsID == PersonalDetailsID).FirstOrDefault();
            return View("PersonalDetails", pdetail);
        }
    }
}
