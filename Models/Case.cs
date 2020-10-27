using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace C19Test2.Models
{
    public class Case
    {
        public int CaseID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string LastName { get; set; }

        [StringLength(10, MinimumLength = 9)]
        [Required]
        public string SNumber { get; set; }

        [Display(Name = "Exposure Date")]
        [DataType(DataType.Date)]
        public DateTime ExposureDate { get; set; }

        [Required]
        public int StatusID { get; set; }
        [Required]
        public int LocationID { get; set; }
        public int DepartmentID { get; set; }

        // navigation properties to get foreign key data
        public Status Status { get; set; }
        public Location Location { get; set; }
        public Department Department { get; set; }


    }
}
