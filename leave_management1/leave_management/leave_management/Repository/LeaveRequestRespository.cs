using leave_management.Contract;
using leave_management.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Repository
{
    public class LeaveRequestRespository
    : ILeaveRequestRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveRequestRespository(ApplicationDbContext _db)
        {
            this._db = _db;
        }
        public bool Create(LeaveRequest entity)
        {
            _db.LeaveRequest.Add(entity);
            return Save();
        }

        public bool Delete(LeaveRequest entity)
        {
            _db.LeaveRequest.Remove(entity);
            return Save();
        }

        public ICollection<LeaveRequest> FindAll()
        {
            return _db.LeaveRequest
                .Include(x=>x.ApprovedBy).Include(x => x.RequestingEmployee)
                .Include(x=>x.LeaveType).ToList();
        }

        public LeaveRequest FindById(int id)
        {
            return FindAll().FirstOrDefault(x=>x.Id == id);
        }

        public ICollection<LeaveRequest> GetLeaveRequestsByEmployee(string employeeId)
        {
            var leaveRequests = _db.LeaveRequest.Include(x => x.RequestingEmployee)
                 .Include(x => x.ApprovedBy)
                 .Include(x => x.LeaveType)
                 .Where(x => x.RequestingEmployeeId == employeeId);

            return leaveRequests.ToList();
        }

        public bool isExist(int id)
        {
            var exists = _db.LeaveRequest.Any(x => x.Id.Equals(id));
            return exists;
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;
        }

        public bool Update(LeaveRequest entity)
        {
            _db.LeaveRequest.Update(entity);
            return Save();
        }
    }
}
