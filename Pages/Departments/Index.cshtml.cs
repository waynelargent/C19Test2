using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using C19Test2.Data;
using C19Test2.Models;

namespace C19Test2.Pages.Departments
{
    public class IndexModel : PageModel
    {
        private readonly C19Test2.Data.C19Test2Context _context;

        public IndexModel(C19Test2.Data.C19Test2Context context)
        {
            _context = context;
        }

        public IList<Department> Department { get;set; }

        public async Task OnGetAsync()
        {
            Department = await _context.Department.ToListAsync();
        }
    }
}
