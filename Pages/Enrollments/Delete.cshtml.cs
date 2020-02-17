using System;
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
    //Delets all entrollments
    public class DeleteModel : PageModel
    {
        private readonly Online_Courses_Core_Web.Models.Online_Courses_Core_DataBaseContext _context;

        public DeleteModel(Online_Courses_Core_Web.Models.Online_Courses_Core_DataBaseContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Enrollment = await _context.Enrollment.FindAsync(id);

            if (Enrollment != null)
            {
                _context.Enrollment.Remove(Enrollment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
