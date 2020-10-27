using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using C19Test2.Data;
using C19Test2.Models;
using Microsoft.EntityFrameworkCore;

namespace C19Test2.Pages.Cases
{
    public class CreateModel : PageModel
    {
        private readonly C19Test2.Data.C19Test2Context _context;

        public CreateModel(C19Test2.Data.C19Test2Context context)
        {
            _context = context;
        }

        public async Task<PageResult> OnGetAsync()
        {
            StatusSL = await _context.Status.ToListAsync();
            LocationSL = await _context.Location.ToListAsync();
            DepartmentSL = await _context.Department.ToListAsync();
            return Page();
        }

        [BindProperty]
        public Case Case { get; set; }
        public IList<Status> StatusSL { get; set; }
        public IList<Location> LocationSL { get; set; }
        public IList<Department> DepartmentSL { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Case.Add(Case);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
