using HR_Employee.Data;
using HR_Employee.Interfaces;
using HR_Employee.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Employee.DataManager
{
    public class EmployeeManager : IEmployee
    {
        private readonly HR_Employee_Context _context;
        public EmployeeManager(HR_Employee_Context context)
        {
            _context = context;
        }

        public async Task AddAsync(Employee employee)
        {
            _context.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetAsync()
        {
            return await _context.Employees.Include(s=>s.Gender).ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
           return await _context.Employees.Include(s=>s.Gender)
             .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Gender>> GetGendersAsync()
        {
            return await _context.Genders.ToListAsync();
        }

        public async Task<int> UpdateAsync(Employee employee)
        {
            try
            {
                _context.Update(employee);
                await _context.SaveChangesAsync();
                return employee.Id;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(employee.Id))
                {
                    return 0;
                }
                else
                {
                    throw;
                }
            }


         
        }


        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
