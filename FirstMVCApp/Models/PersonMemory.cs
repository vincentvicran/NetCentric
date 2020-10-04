using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestingNetNetCore.Models;

namespace FirstMVCApp.Models
{
    public class PersonMemory
    {
        private static List<PersonalDetail> detailList = new List<PersonalDetail>();

      
        public static List <PersonalDetail> GetPersons()
        {
            if (detailList.Count == 0)
            {
                PersonalDetail hari = new PersonalDetail()
                {
                    PersonalDetailId = 1,
                    FirstName = "Hari Krishna",
                    Address = "Gothatar, Kathmandu",
                    Age = 56,
                    Occupation = "Doctor",
                };
                detailList.Add(hari);


                //sanil as a farmer
                PersonalDetail sanil = new PersonalDetail()
                {
                    PersonalDetailId = 2,
                    FirstName = "Sanil Desemaru",
                    Address = "Dudhpati, Bhaktapur",
                    Age = 24,
                    Occupation = "Farmer"
                };
                detailList.Add(sanil);


                //adit as a farmer
                PersonalDetail adit = new PersonalDetail()
                {
                    PersonalDetailId = 3,
                    FirstName = "Adit Dahal",
                    Address = "Dudhpati, Bhaktapur",
                    Age = 24,
                    Occupation = "Farmer"
                };
                detailList.Add(adit);


                //bhanu as a student
                PersonalDetail bhanu = new PersonalDetail()
                {
                    PersonalDetailId = 4,
                    FirstName = "Bhanu Shrestha",
                    Address = "Dudhpati, Bhaktapur",
                    Age = 24,
                    Occupation = "Student",
                };
                detailList.Add(bhanu);


                // saurav as a student
                PersonalDetail saurav = new PersonalDetail()
                {
                    PersonalDetailId = 5,
                    FirstName = "Saurav Dhami",
                    Address = "Gothatar, Kathmandu",
                    Age = 56,
                    Occupation = "Student",
                };
                detailList.Add(saurav);



                //nikita as a student
                PersonalDetail nikita = new PersonalDetail()
                {
                    PersonalDetailId = 6,
                    FirstName = "Nikita Shrestha",
                    Address = "Gothatar, Kathmandu",
                    Age = 56,
                    Occupation = "Student"
                };
                detailList.Add(nikita);

            }
            return detailList;
        }
        }
    }

