using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KZLBydgoszcz.Models
{
    public class Class_Name
    {
        [Key]
        public int Student_classID { get; set; }
        [StringLength(5)]
        [Required(ErrorMessage = "Pole wymagane")]
        [Display(Name = "Numer klasy")]
        public string   Class_identificator { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Lessons> Lessons { get; set; }
    }
}
