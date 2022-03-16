using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API.Models;
using Web_API.Services;

namespace Web_API.Repository
{
    public class EmployeeRepository : IEmployee
    {
        public List<Employee> GetEmployees()
        {
           return new List<Employee>()
            {
               new Employee { Id = 1, Name = "Yash", City = "Pune" },
               new Employee { Id = 2, Name = "Nilesh", City = "Nagpur" },
               new Employee { Id = 3, Name = "Abhi", City = "Amravati" },
               new Employee { Id = 4, Name = "Manoj", City = "Pune" }

            };
            
        }
    }
}
