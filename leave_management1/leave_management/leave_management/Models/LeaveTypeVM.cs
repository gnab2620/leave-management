using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Models
{
    public class LeaveTypeVM
    {
        public int Id { get; set; }
       [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name="Default Number of days")]
        [Range(1,25,ErrorMessage ="Please enter valid number")]
        public int DefaultDays { get; set; }
        public DateTime? DateCreated { get; set; }
    }
   
}
