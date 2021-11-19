using AutoMapper;
using leave_management.Contract;
using leave_management.Data;
using leave_management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace leave_management.Controllers
{
    [Authorize(Roles ="Administrator")]
    public class LeaveTypeController : Controller
    {
        private readonly ILeaveTypeRespository _repo;
        private readonly IMapper _mapper;

        public LeaveTypeController(ILeaveTypeRespository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [Authorize]
        // GET: LeaveTypeController
        public ActionResult Index()
        {
            var leaveType = _repo.FindAll().ToList();
            var model = _mapper.Map<List<LeaveType>, List<LeaveTypeVM>>(leaveType);
            return View(model);
        }
        [Authorize]
        // GET: LeaveTypeController/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.isExist(id))
            {
                return NotFound();
            }
            var leaveType = _repo.FindById(id);
            var model = _mapper.Map<LeaveTypeVM>(leaveType);

            return View(model);
        }
        [Authorize]
        // GET: LeaveTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeaveTypeVM collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }
                var model = _mapper.Map<LeaveType>(collection);
                model.DateCreated = DateTime.Now;
                var isSuccess = _repo.Create(model);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Somthing went wrong");
                    return View(collection);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [Authorize]
        // GET: LeaveTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.isExist(id))
            {
                return NotFound();
            }
            var leaveType = _repo.FindById(id);
            var model = _mapper.Map<LeaveTypeVM>(leaveType);

            return View(model);
        }

        // POST: LeaveTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LeaveTypeVM collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }
                var model = _mapper.Map<LeaveType>(collection);

                var isSuccess = _repo.Update(model);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Somthing went wrong");
                    return View(collection);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Somthing went wrong");
                return View();
            }
        }
        [Authorize]
        // GET: LeaveTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            if (!_repo.isExist(id))
            {
                return NotFound();
            }
            var leaveType = _repo.FindById(id);

            var isSuccess = _repo.Delete(leaveType);
            if (!isSuccess)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: LeaveTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, LeaveTypeVM collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }
                var model = _mapper.Map<LeaveType>(collection);
                var isSuccess = _repo.Delete(model);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Somthing went wrong");
                    return View(collection);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}