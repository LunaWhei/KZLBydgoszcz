using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KZLBydgoszcz.Models;

namespace KZLBydgoszcz.Models
{
    public class StudentContext:DbContext
    {
        public StudentContext()
        {

        }
        public StudentContext(DbContextOptions<StudentContext> options): base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Class_Name> class_Names { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Lessons> Lessons { get; set; }
    }
}
