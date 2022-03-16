using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API.Models;

namespace Web_API.Services
{
   public interface IEmployee
    {
        List<Employee> GetEmployees();
    }
}
