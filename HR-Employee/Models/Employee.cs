using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Employee.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "First Name is required field")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required field")]
        public string LastName { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime DateOfBith { get; set; }
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        public double Salary { get; set; }

    }
}
