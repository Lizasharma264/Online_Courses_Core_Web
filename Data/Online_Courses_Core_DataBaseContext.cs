using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Online_Courses_Core_Web.BusinessLayer;

namespace Online_Courses_Core_Web.Models
{
    public class Online_Courses_Core_DataBaseContext : DbContext
    {
        public Online_Courses_Core_DataBaseContext (DbContextOptions<Online_Courses_Core_DataBaseContext> options)
            : base(options)
        {
        }

        public DbSet<Online_Courses_Core_Web.BusinessLayer.Course> Course { get; set; }

        public DbSet<Online_Courses_Core_Web.BusinessLayer.Enrollment> Enrollment { get; set; }

        public DbSet<Online_Courses_Core_Web.BusinessLayer.Instructor> Instructor { get; set; }

        public DbSet<Online_Courses_Core_Web.BusinessLayer.Student> Student { get; set; }
    }
}
