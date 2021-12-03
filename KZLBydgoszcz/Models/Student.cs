using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KZLBydgoszcz.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Imie ucznia")]
        public string FirstName { get; set; }
        [Display(Name = "Nazwisko ucznia")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Pole jest wymagane")]
        [DataType(DataType.Date)]
        [Display(Name = "Data Urodzenia")]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "Pole wymagane")]
        [Display(Name = "Średnia ocen z poprzedniego roku (float)")]
        public float AvgGrade { get; set; }
        [Required(ErrorMessage = "Pole wymagane")]
        [Display(Name = "Identyfikator Klasy")]
        public int Student_classID { get; set; }
        public string Class_identificator { get; }
        public virtual Class_Name Student_class { get; set; }
    }
}
