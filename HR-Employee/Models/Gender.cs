using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Employee.Models
{
    public class Gender
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; }

    }
}
