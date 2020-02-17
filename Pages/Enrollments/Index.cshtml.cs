﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Online_Courses_Core_Web.BusinessLayer;
using Online_Courses_Core_Web.Models;

namespace Online_Courses_Core_Web.Pages.Enrollments
{
    //Gets all enrollments
    public class IndexModel : PageModel
    {
        private readonly Online_Courses_Core_Web.Models.Online_Courses_Core_DataBaseContext _context;

        public IndexModel(Online_Courses_Core_Web.Models.Online_Courses_Core_DataBaseContext context)
        {
            _context = context;
        }

        public IList<Enrollment> Enrollment { get;set; }

        public async Task OnGetAsync()
        {
            Enrollment = await _context.Enrollment
                .Include(e => e.Course)
                .Include(e => e.Instructor)
                .Include(e => e.Student).ToListAsync();
        }
    }
}
