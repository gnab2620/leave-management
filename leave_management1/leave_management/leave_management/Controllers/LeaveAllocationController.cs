using AutoMapper;
using leave_management.Contract;
using leave_management.Data;
using leave_management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class LeaveAllocationController : Controller
    {
        private readonly ILeaveTypeRespository _leavetyperepo;
        private readonly ILeaveAllocationRepository _leaveallocationrepo;
        private readonly IMapper _mapper;
        private readonly UserManager<Employee> _userManager;

        public LeaveAllocationController(ILeaveTypeRespository leavetyperepo, ILeaveAllocationRepository leaveallocationrepo, IMapper mapper
            , UserManager<Employee> userManager)
        {
            _leavetyperepo = leavetyperepo;
            _leaveallocationrepo = leaveallocationrepo;
            _mapper = mapper;
            _userManager = userManager;
        }

        public ActionResult ListEmployee()
        {
            var employee = _userManager.GetUsersInRoleAsync("Employee").Result;
            var model = _mapper.Map<List<EmployeeVM>>(employee);
            return View(model);

        }

        public ActionResult SetLeave(int id)
        {
            var leaveType = _leavetyperepo.FindById(id);
            var employees = _userManager.GetUsersInRoleAsync("Employee").Result;
            foreach (var item in employees)
            {
                if (_leaveallocationrepo.CheckAllocation(id,item.Id))
                {
                    continue;
                }
                var allocation = new LeaveAllocationVM
                {
                    DateCreated = DateTime.Now,
                    EmployeeId = item.Id,
                    LeaveTypeId = id,
                    NumberOfDays = leaveType.DefaultDays,
                    Period = DateTime.Now.Year
                };
                var leaveAllocation = _mapper.Map<LeaveAllocation>(allocation);
                _leaveallocationrepo.Create(leaveAllocation);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: LeaveAllocationController
        public ActionResult Index()
        {
            var leaveType = _leavetyperepo.FindAll().ToList();
            var mappLeaveTypeVM = _mapper.Map<List<LeaveType>, List<LeaveTypeVM>>(leaveType);
            var model = new CreateLeaveAllocationVM
            {
                LeaveType = mappLeaveTypeVM,
                NumberUpdated = 0

            };


            return View(model);
            
        }

        // GET: LeaveAllocationController/Details/5
        public ActionResult Details(string id)
        {

        
            var employee = _mapper.Map<EmployeeVM>(_userManager.FindByIdAsync(id).Result);
            var allocation = _mapper.Map<List<LeaveAllocationVM>>(_leaveallocationrepo.GetLeaveAllocationByEmployee(id));
            var model = new ViewLeaveAllocationVM
            {
                Employee = employee,
                LeaveAllocations = allocation
            };


            return View(model);
        }

        // GET: LeaveAllocationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveAllocationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveAllocationController/Edit/5
        public ActionResult Edit(int id)
        {
            var leavealocation = _leaveallocationrepo.FindById(id);
            var model = _mapper.Map<EditLeaveAllocationVM>(leavealocation);

            return View(model);
        }

        // POST: LeaveAllocationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( EditLeaveAllocationVM collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }
                var model = _leaveallocationrepo.FindById(collection.Id);
                model.NumberOfDays = collection.NumberOfDays;

                var isSuccess = _leaveallocationrepo.Update(model);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Somthing went wrong");
                    return View(collection);
                }

               
                return RedirectToAction(nameof(Details), new { id = model.EmployeeId});
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveAllocationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LeaveAllocationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
