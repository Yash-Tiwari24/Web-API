using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API.Models;
using Web_API.Services;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomer _customer;
        public CustomersController(ICustomer customer)
        {
            _customer = customer;
        }

        [HttpGet]
        [Route("Get_Customers")]
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _customer.GetAllCustomers();
        }

        [HttpGet]
        [Route("Get_Customer_By_Id")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            return await _customer.GetById(id);
        }

        [HttpPost]
        [Route("Create_Customer")]
        public async Task<ActionResult<Customer>> PostCustomer([FromBody] Customer customer)
        {
            var newCustomer = await _customer.Create(customer);
            return CreatedAtAction(nameof(GetCustomer), new { id = newCustomer.CustomerID }, newCustomer);
        }

        [HttpPut]
        [Route("Update_Customer")]
        public async Task<ActionResult> PutCustomer(int id, [FromBody] Customer customer)
        {
            if (id != customer.CustomerID)
            {
                return BadRequest();
            }

            await _customer.Update(customer);

            return Ok("Sucessfully Updated");
        }

        [HttpDelete]
        [Route("Delete_Customer")]
        public async Task<ActionResult> Delete(int id)
        {
            var customerToDelete = await _customer.GetById(id);
            if (customerToDelete == null)
                return NotFound();

            await _customer.Delete(customerToDelete.CustomerID);
            return Ok("Deleted");
        }

    }
}
