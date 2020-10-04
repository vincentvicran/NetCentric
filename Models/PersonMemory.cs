using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace simplenetcoreapp.Models
{
    public class PersonMemory
    {
        private static List<PersonalDetails> detailList = new List<PersonalDetails>();

        public static List<PersonalDetails> GetPersons()
        {
            if (detailList.Count == 0)
            {
                DoctorProfile Vicran = new DoctorProfile()
                {
                    PersonalDetailsID = 1,
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
                    PersonalDetailsID = 2,
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
                    PersonalDetailsID = 3,
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
            return detailList;
        }
    }
}
