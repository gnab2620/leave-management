using leave_management.Mappings;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Models
{
    public class LeaveRequestVM
    {
        public int Id { get; set; }

        public EmployeeVM RequestingEmployee { get; set; }
        [Display(Name ="Employee Name: ")]
        public string RequestingEmployeeId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public LeaveTypeVM LeaveType { get; set; }
        public int LeaveTypeId { get; set; }

        public DateTime DateRequest { get; set; }

        public DateTime DateActioned { get; set; }
        public bool? Approved { get; set; }
        public EmployeeVM ApprovedBy { get; set; }
        public string ApprovedById { get; set; }

    }

    public class AdminViewLeaveRequestVM
    {
        [Display(Name ="Total Number Of Requests")]
        public int TotalRequests { get; set; }
        [Display(Name = "Approved Request")]
        public int ApproveRequests { get; set; }
        [Display(Name = "Pending Request")]
        public int PendingRequests { get; set; }
        [Display(Name = "Reject Request")]
        public int RejectRequests { get; set; }

        public List<LeaveRequestVM> LeaveRequests { get; set; }

    }
    public class CreateLeaveRequestVM
    {
        [Display(Name ="Start Date")]
        [Required]
        public string StartDate { get; set; }
        [Display(Name = "End Date")]
        [Required]
        public string EndDate { get; set; }

        public IEnumerable<SelectListItem> LeaveTypes { get; set; }
        [Display(Name = "Leave Type")]
        public int LeaveTypeId { get; set; }
    }
    public class EmployeeLeaveRequestViewVM
    {
        public List<LeaveAllocationVM> LeaveAllocations { get; set; }
        public List<LeaveRequestVM> LeaveRequests { get; set; }
    }
}
