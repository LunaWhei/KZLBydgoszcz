using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KZLBydgoszcz.Models
{
    public class Lessons
    {
        [Key]
        public int LessonID { get; set; }
        [Required(ErrorMessage = "Pole wymagane")]
        [Display(Name = "Przedmiot")]
        public string LessonName { get; set; }
        [Required(ErrorMessage = "Pole wymagane")]
        [Display(Name = "Klasa")]
        public int Student_classID { get; set; }
        public virtual Class_Name Student_class { get; set; }
        [Required(ErrorMessage = "Pole wymagane")]
        [Display(Name = "Nauczyciel")]
        public int TeachersId { get; set; }
        public virtual Teacher Teachers { get; set; }
        

    }
}
