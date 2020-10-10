using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstMVCApp.Models
{
    public class PersonalDetail
    {
        public PersonalDetail()
        {
        }

        // properties
        public int PersonalDetailId { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        [DisplayName("Full Name *")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string Address { get; set; }

        [Required(ErrorMessage = "Age is required!")]
        [Range(18, 30, ErrorMessage = "Age must be between 18 and 30!")]
        [DisplayName("Age *")]
        public int Age { get; set; }

        public string Occupation { get; set; }

        public Decimal weight { get; set; } 

        public DateTime DOB { get; set; }

    }

    
    

}
