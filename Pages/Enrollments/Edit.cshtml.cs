using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Online_Courses_Core_Web.BusinessLayer;
using Online_Courses_Core_Web.Models;

namespace Online_Courses_Core_Web.Pages.Enrollments
{
    //Modifies the enrollment
    public class EditModel : PageModel
    {
        private readonly Online_Courses_Core_Web.Models.Online_Courses_Core_DataBaseContext _context;

        public EditModel(Online_Courses_Core_Web.Models.Online_Courses_Core_DataBaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Enrollment Enrollment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Enrollment = await _context.Enrollment
                .Include(e => e.Course)
                .Include(e => e.Instructor)
                .Include(e => e.Student).FirstOrDefaultAsync(m => m.Id == id);

            if (Enrollment == null)
            {
                return NotFound();
            }
           ViewData["CourseId"] = new SelectList(_context.Course, "Id", "CourseName");
           ViewData["InstructorId"] = new SelectList(_context.Set<Instructor>(), "Id", "Name");
           ViewData["StudentId"] = new SelectList(_context.Set<Student>(), "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Enrollment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnrollmentExists(Enrollment.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EnrollmentExists(int id)
        {
            return _context.Enrollment.Any(e => e.Id == id);
        }
    }
}
