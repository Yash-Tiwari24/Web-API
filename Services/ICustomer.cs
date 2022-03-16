using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API.Models;

namespace Web_API.Services
{
    public interface ICustomer
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<Customer> GetById(int id);
        Task<Customer> Create(Customer customer);
        Task Update(Customer customer);
        Task Delete(int id);

    }
}
