using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HR_Employee.Data;
using HR_Employee.Models;
using HR_Employee.Interfaces;

namespace HR_Employee.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee _dataRepository;

        public EmployeeController(IEmployee dataRepository)
        {
            _dataRepository = dataRepository;

        }

        // GET: Employee
        public async Task<IActionResult> Index()
        {
            return View(await _dataRepository.GetAsync());
        }

        // GET: Employee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _dataRepository.GetByIdAsync(id ?? 0);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employee/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.GenderId = new SelectList(await _dataRepository.GetGendersAsync(), "Id", "Name");
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,DateOfBith,GenderId,Salary")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _dataRepository.AddAsync(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _dataRepository.GetByIdAsync(id ?? 0);
            if (employee == null)
            {
                return NotFound();
            }
            ViewBag.GenderId = new SelectList(await _dataRepository.GetGendersAsync(), "Id", "Name");
            return View(employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,DateOfBith,GenderId,Salary")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var employee_id = await _dataRepository.UpdateAsync(employee);
                if (employee_id == 0)
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _dataRepository.GetByIdAsync(id ?? 0);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _dataRepository.DeleteByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
