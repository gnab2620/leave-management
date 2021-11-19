using AutoMapper;
using leave_management.Contract;
using leave_management.Data;
using leave_management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace leave_management.Controllers
{
    [Authorize]
    public class LeaveRequestController : Controller
    {
        private readonly ILeaveRequestRepository _leaveRequestRepo;
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRespository _leavetyprepo;
        private readonly ILeaveAllocationRepository _leaveallocationrepo;
        private readonly UserManager<Employee> _userManager;

        public LeaveRequestController(ILeaveRequestRepository leaveRequestRepo, IMapper mapper, ILeaveTypeRespository leavetyprepo, ILeaveAllocationRepository leaveallocationrepo, UserManager<Employee> userManager)
        {
            _leaveRequestRepo = leaveRequestRepo;
            _mapper = mapper;
            _leavetyprepo = leavetyprepo;
            _leaveallocationrepo = leaveallocationrepo;
            _userManager = userManager;
        }

        [Authorize(Roles = "Administrator")]
        // GET: LeaveRequestController
        public ActionResult Index()
        {
            var leaverequest = _leaveRequestRepo.FindAll();
            var collection = _mapper.Map<List<LeaveRequestVM>>(leaverequest);
            var model = new AdminViewLeaveRequestVM
            {
                TotalRequests = collection.Count,
                ApproveRequests = collection.Count(x => x.Approved == true),
                PendingRequests = collection.Count(x => x.Approved == null),
                RejectRequests = collection.Count(x => x.Approved == false),
                LeaveRequests = collection
            };

            return View(model);
        }

        // GET: LeaveRequestController/Details/5
        public ActionResult Details(int id)
        {
            var leaverequest = _leaveRequestRepo.FindById(id);
            var model = _mapper.Map<LeaveRequestVM>(leaverequest);

            return View(model);
        }  

        public ActionResult MyLeave()
        {
            var employee = _userManager.GetUserAsync(User).Result;
            var empid = employee.Id;
            var empAllocation = _leaveallocationrepo.GetLeaveAllocationByEmployee(empid);
            var empRequest = _leaveRequestRepo.GetLeaveRequestsByEmployee(empid);

            var employeeAlloModel = _mapper.Map<List<LeaveAllocationVM>>(empAllocation);
            var employeeRequestModel = _mapper.Map<List<LeaveRequestVM>>(empRequest);

            var model = new EmployeeLeaveRequestViewVM
            {
                LeaveAllocations = employeeAlloModel,
                LeaveRequests = employeeRequestModel
            };
            return View(model);

        }
        public ActionResult ApproveRequest(int id)
        {
            try
            {
                var employee = _userManager.GetUserAsync(User).Result;
                var leaverequest = _leaveRequestRepo.FindById(id);
                var allocation = _leaveallocationrepo.GetLeaveAllocationByEmployeeAndType
                    (leaverequest.RequestingEmployeeId,leaverequest.LeaveTypeId);
                int daterequest = (int)(leaverequest.EndDate - leaverequest.StartDate).TotalDays;
                allocation.NumberOfDays -= daterequest;
                leaverequest.Approved = true;
                leaverequest.ApprovedById = employee.Id;
                leaverequest.DateActioned = DateTime.Now;

                _leaveRequestRepo.Update(leaverequest);
                _leaveallocationrepo.Update(allocation);
                return RedirectToAction(nameof(Index));
                
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }


        }
        
        public ActionResult RejectRequest(int id)
        {
            try
            {
                var employee = _userManager.GetUserAsync(User).Result;
                var leaverequest = _leaveRequestRepo.FindById(id);
                leaverequest.Approved = false;
                leaverequest.ApprovedById = employee.Id;
                leaverequest.DateActioned = DateTime.Now;

                _leaveRequestRepo.Update(leaverequest);
                return RedirectToAction(nameof(Index));

            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }

        }
        public ActionResult CancelRequest(int id)
        {
            try
            {
                var leaverequest = _leaveRequestRepo.FindById(id);
               

                _leaveRequestRepo.Delete(leaverequest);
                return RedirectToAction("MyLeave");

            }
            catch (Exception)
            {
                return RedirectToAction("MyLeave");
            }

        }
        // GET: LeaveRequestController/Create
        public ActionResult Create()
        {

            var leavetype = _leavetyprepo.FindAll();
            var leavetypeitem = leavetype.Select(q => new SelectListItem
            {
                Text = q.Name,
                Value = q.Id.ToString()

            });
            var model = new CreateLeaveRequestVM
            {
                LeaveTypes = leavetypeitem,

            };


            return View(model);
        }

        // POST: LeaveRequestController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateLeaveRequestVM collection)
        {
            try
            {
                var startDate = Convert.ToDateTime(collection.StartDate);
                var endDate = Convert.ToDateTime(collection.EndDate);
                var leaveType = _leavetyprepo.FindAll();
                var leavetypeitem = leaveType.Select(x =>new SelectListItem { 
                    Text= x.Name,
                    Value = x.Id.ToString()
                });
                collection.LeaveTypes = leavetypeitem;
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }
                if (DateTime.Compare(startDate,endDate)>1)
                {
                    ModelState.AddModelError("", "Start Date cannot be further than End Date");   
                    return View(collection);
                }
                var employee = _userManager.GetUserAsync(User).Result;
                var allocation = _leaveallocationrepo.GetLeaveAllocationByEmployeeAndType(employee.Id,collection.LeaveTypeId);
                int daterequest = (int) (endDate.Date - startDate.Date).TotalDays;

                if (daterequest>allocation.NumberOfDays)
                {
                    ModelState.AddModelError("", "you do not sufficent for this request");
                    return View(collection);
                }

                var leaverequestModel = new LeaveRequestVM
                {
                    RequestingEmployeeId = employee.Id,
                    StartDate = startDate,
                    EndDate = endDate,
                    Approved = null,
                    DateRequest = DateTime.Now,
                    DateActioned = DateTime.Now,
                    LeaveTypeId = collection.LeaveTypeId
                };
                var leaverequest = _mapper.Map<LeaveRequest>(leaverequestModel);
                if (!_leaveRequestRepo.Create(leaverequest))
                {
                    ModelState.AddModelError("", "Something went wrong");
                    return View(collection);
                }
                

                return RedirectToAction("MyLeave");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Something went wrong");
                return View();
            }
        }

        // GET: LeaveRequestController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LeaveRequestController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: LeaveRequestController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LeaveRequestController/Delete/5
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