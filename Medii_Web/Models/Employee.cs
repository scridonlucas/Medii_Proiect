using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectMedii.Models
{
    public class Employee
    {
        public int ID { get; set; }
        [Display(Name = "Nume")]
        [RegularExpression(@"^[A-Z][a-z]{2,}", ErrorMessage = "Numele trebuie să înceapă cu literă mare și să aibă cel puțin 3 litere")]
        [Required(ErrorMessage = "Acest câmp este obligatoriu de completat")]
        public string FirstName { get; set; }
        [Display(Name = "Prenume")]
        [RegularExpression(@"^[A-Z][a-z]{2,}", ErrorMessage = "Prenumele trebuie să înceapă cu literă mare și să aibă cel puțin 3 litere")]
        [Required(ErrorMessage = "Acest câmp este obligatoriu de completat")]
        public string LastName { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
        public ICollection<Service> Services { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
