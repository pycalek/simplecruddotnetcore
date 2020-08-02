using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCrud.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public int EmployeeNumber { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IDNumber { get; set; }
        public string Address { get; set; } 
    }
}
