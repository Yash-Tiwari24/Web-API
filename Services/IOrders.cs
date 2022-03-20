using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API.Models;

namespace Web_API.Services
{
   public interface IOrders
    {
        
        IEnumerable<Orders> GetAllOrder();
        Orders Create(Orders orders);
        void Update(Orders orders);
        void Delete(int Id);
        Orders GetByOrderId(int Id);
      
    }
}
