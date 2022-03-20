using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API.Models
{
    public class Orders
    {
        public float OrderID { get; set; }
        public float CustomerID { get; set; }
        public float EmployeeID { get; set; }
        public DateTime OrderDate { get; set; }
        public float ShipperID { get; set; }
       


    }
}
