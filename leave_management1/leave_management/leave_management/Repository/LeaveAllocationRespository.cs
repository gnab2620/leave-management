using leave_management.Contract;
using leave_management.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Repository
{
    public class LeaveAllocationRespository
    : ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveAllocationRespository(ApplicationDbContext _db)
        {
            this._db = _db;
        }

        public bool CheckAllocation(int leaveTypeId, string employeeid)
        {
            var period = DateTime.Now.Year;
            return FindAll().Where(x => x.EmployeeId.Equals(employeeid) 
            && x.LeaveTypeId.Equals(leaveTypeId) && x.Period == period).Any();
        }

        public bool Create(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Add(entity);
            return Save();
        }   

        public bool Delete(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Remove(entity);
            return Save();
        }

        public ICollection<LeaveAllocation> FindAll()
        {
            var fillall = _db.LeaveAllocations.Include(x => x.LeaveType).Include(x => x.Employee).ToList();

            return fillall;
        }

        public LeaveAllocation FindById(int id)
        {
            return FindAll().FirstOrDefault(x=>x.Id.Equals(id));
        }

        public ICollection<LeaveAllocation> GetLeaveAllocationByEmployee(string id)
        {
            var period = DateTime.Now.Year;
            return FindAll().Where(x => x.EmployeeId.Equals(id) && x.Period == period).ToList();
        }

        public LeaveAllocation GetLeaveAllocationByEmployeeAndType(string id, int leaveType)
        {

            var period = DateTime.Now.Year;
            var leaveallocation = FindAll().FirstOrDefault(x => x.EmployeeId.Equals(id) && x.Period == period && x.LeaveTypeId == leaveType);
            return leaveallocation;
        }

        public bool isExist(int id)
        {
            var exists = _db.LeaveAllocations.Any(x => x.Id.Equals(id));
            return exists;
        }

        public bool Save()
        {
            return _db.SaveChanges()>0;
        }

        public bool Update(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Update(entity);
            return Save();
        }
    }
}
