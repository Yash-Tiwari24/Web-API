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
    public class OrdersController : ControllerBase
    {
        private readonly IOrders _orders;
        public OrdersController(IOrders orders)
        {
            _orders = orders;
        }
        
        [HttpGet]
        [Route("Get_Order_By_Id")]
        public ActionResult<Orders> GetCustomer(int id)
        {
            return  _orders.GetByOrderId(id);
        }

        [HttpGet]
        [Route("Get_All_Orders")]
        public IEnumerable<Orders> GetOrders()
        {
            return _orders.GetAllOrder();
        }

        [HttpPost]
        [Route("Create_Orders")]
        public ActionResult<Customer> PostOrder([FromBody] Orders orders)
        {
            var newOrder =  _orders.Create(orders);
            return CreatedAtAction(nameof(GetOrders), new { id = newOrder.OrderID }, newOrder);
        }

        [HttpPut]
        [Route("Update_Orders")]
        public ActionResult PutOrder(int id, [FromBody] Orders orders)
        {
            if (id != orders.OrderID)
            {
                return BadRequest();
            }

             _orders.Update(orders);

            return Ok("Sucessfully Updated");
        }

        [HttpDelete]
        [Route("Delete_Orders")]
        public ActionResult Delete(int id)
        {
            var orderToDelete =  _orders.GetByOrderId(id);
            if (orderToDelete == null)
                return NotFound();

             _orders.Delete(orderToDelete.OrderID);
            return Ok("Deleted");
        }
    }
}
