using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace simplenetcoreapp.Models
{
    public class PersonalDetails
    {
       /* public PersonalDetails(List<PersonalDetails> persons)
        {
            int personCount = persons.Count;
            PersonalDetailsID = personCount + 1;
        }
*/
       public PersonalDetails()
        { }

        public int PersonalDetailsID { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }


        public string Address { get; set; }
        public int Age { get; set; }
        public string Occupation { get; set; }

    }

    public class DoctorProfile : PersonalDetails
    {
        /*public DoctorProfile(List<PersonalDetails> persons) : base(persons)
        { }*/

        public string Qualification { get; set; }
        public string HospitalClinic { get; set; }
        public string Speciality { get; set; }
    }

    public class TeacherProfile : PersonalDetails
    {
        /*public TeacherProfile(List<PersonalDetails> persons) : base(persons)
        { }*/
        public string Qualification { get; set; }
        public string Institute { get; set; }
        public string AssociatedSubjects { get; set; }
    }

    public class StudentProfile : PersonalDetails
    {
       /* public StudentProfile(List<PersonalDetails> persons) : base(persons)
        { }*/
        public string Faculty { get; set; }
        public string College_School { get; set; }
        public int Rollno { get; set; }
    }

}







