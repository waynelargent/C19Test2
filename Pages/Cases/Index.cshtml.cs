using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using C19Test2.Data;
using C19Test2.Models;

namespace C19Test2.Pages.Cases
{
    public class IndexModel : PageModel
    {
        private readonly C19Test2.Data.C19Test2Context _context;

        public IndexModel(C19Test2.Data.C19Test2Context context)
        {
            _context = context;
        }

        public IList<Case> Case { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SortString { get; set; }

        public async Task OnGetAsync()
        {
            //from d in _context.Document
            //join di in _context.DocumentToIssues on d.DocumentID equals di.DocumentID
            //where d.CountryID == CountryID && IssuesChecked.Contains(di.DocumentID)
            //orderby d.DatePublished descending
            //select d;

            var caseqry = from x in _context.Case
                       //join xs in _context.Status on x.StatusID equals xs.StatusID
                       //join xl in _context.Location on x.LocationID equals xl.LocationID
                       //join xd in _context.Department on x.DepartmentID equals xd.DepartmentID
                   select x;
                   //select new 
                   //       {
                   //           x.LastName,
                   //           x.FirstName,
                   //           x.ExposureDate,
                   //           x.SNumber,
                   //           x.Status.StatusDescription,
                   //           x.Location.LocationDescription,
                   //           x.Department.DepartmentDescription
                   //       };
            //var caseqry = _context.Case.
            //              Include(b => b.Status).
            //              Include(c => c.Location).
            //              Include(d => d.Department);

            if (!string.IsNullOrEmpty(SearchString))
            {
                caseqry = caseqry.Where(s => s.LastName.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(SortString))
            {
                if (SortString == "status")
                {
                    caseqry = caseqry.OrderBy(x => x.Status.StatusDescription);
                }
                if (SortString == "snumber")
                {
                    caseqry = caseqry.OrderBy(x => x.SNumber);
                }
                else if (SortString == "exposuredateA")
                {
                    caseqry = caseqry.OrderBy(x => x.ExposureDate);
                }
                else if (SortString == "exposuredateD")
                {
                    caseqry = caseqry.OrderByDescending(x => x.ExposureDate);
                }
                else
                {
                    caseqry = caseqry.OrderBy(x => x.LastName);
                }
            }
            Case = await caseqry.ToListAsync();
        }
    }
}
