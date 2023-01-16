using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectMedii.Models
{
    public class Service
    {
        public int ID { get; set; }
        [Display(Name = "Nume")]
        [RegularExpression(@"^[A-Z][a-z+\s]{3,40}", ErrorMessage = "Numele serviciului trebuie să înceapă cu literă mare, să conțină doar litere sau caracterul + și să fie cuprins între 4 și 40 de caractere")]
        [Required(ErrorMessage = "Acest câmp este obligatoriu de completat")]
        public string Name { get; set; }
        [Display(Name = "Preț")]
        [RegularExpression(@"\d{2,3}", ErrorMessage = "Prețul trebuie să aibă 2 sau 3 cifre")]
        [Required(ErrorMessage = "Acest câmp este obligatoriu de completat")]
        public int Price { get; set; }
        [Display(Name = "Durată (minute)")]
        [Required(ErrorMessage = "Acest câmp este obligatoriu de completat")]
        public int Duration { get; set; }
        public int EmployeeID { get; set; }
        [Display(Name = "Numele angajatului")]
        public Employee Employee { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
