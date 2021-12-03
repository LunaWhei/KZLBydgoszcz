using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KZLBydgoszcz.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        [StringLength(20)]
        [Required(ErrorMessage = "Pole wymagane")]
        [Display(Name = "Imie nauczyciela")]
        public string FirstName { get; set; }
        [StringLength(20)]
        [Required(ErrorMessage = "Pole wymagane")]
        [Display(Name = "Nazwisko nauczyciela")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Pole wymagane")]
        [Display(Name = "Etat - liczba (float)")]

        public float full_time { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Pole wymagane")]
        [Display(Name = "Data Rozpoczęcia pracy")]

        public DateTime WorkStartDate { get; set; }
        public virtual ICollection<Lessons> Lessons { get; set; }

    }
}
