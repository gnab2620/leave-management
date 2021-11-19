using leave_management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Contract
{
    public interface ILeaveAllocationRepository
        : IRepositoryBase<LeaveAllocation>
    {
        bool CheckAllocation(int leaveTypeId, string employeeid);

        ICollection<LeaveAllocation> GetLeaveAllocationByEmployee(string id);
        LeaveAllocation GetLeaveAllocationByEmployeeAndType(string id,int leaveType);
    }
}
