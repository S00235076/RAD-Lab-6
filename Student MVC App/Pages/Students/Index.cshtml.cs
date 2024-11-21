using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Student_Class_Library;
using Student_MVC_App;

namespace Student_MVC_App.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly Student_MVC_App.CollegeContext _context;

        public IndexModel(Student_MVC_App.CollegeContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Student = await _context.Students.ToListAsync();
        }
    }
}
