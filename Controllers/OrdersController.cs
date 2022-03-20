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
        [Route("Get_All_Orders")]
        public IEnumerable<Orders> GetOrders()
        {
            return _orders.GetAllOrder();
        }
    }
}
