using HR_Employee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Employee.Interfaces
{
    public interface IEmployee
    {
        Task<List<Employee>> GetAsync();

        Task<Employee> GetByIdAsync(int id);

        Task AddAsync(Employee employee);
        Task<int> UpdateAsync(Employee employee);
        Task DeleteByIdAsync(int id);


        //to be moved
        Task<List<Gender>> GetGendersAsync();


    }
}
