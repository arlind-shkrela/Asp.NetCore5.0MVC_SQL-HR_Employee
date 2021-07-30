using HR_Employee.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Employee.Data
{
    public class HR_Employee_Context : DbContext
    {
        public HR_Employee_Context(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Gender> Genders { get; set; }

    }

}
