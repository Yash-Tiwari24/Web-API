using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Web_API.Models;
using Web_API.Services;

namespace Web_API.Repository
{
    public class OrderRepository : IOrders
    {
        private readonly string _connectionString;

        public OrderRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlConcept");
        }
        public Orders Create(Orders orders)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sqlQuery = "insert into Orders(OrderID, CustomerID,EmployeeID,OrderDate,ShipperID) values (@OrderID, @CustomerID,@EmployeeID,@OrderDate,@ShipperID)";
                connection.Execute(sqlQuery, orders);
                return orders;
            }

        }

        public void Delete(int Id)
        {
            using (var connection=new SqlConnection(_connectionString))
            {
                var sqlQuery = "delete from Orders where OrderID=@OrderID";
                connection.Execute(sqlQuery,new { OrderID =Id});

            }
        }

        public IEnumerable<Orders> GetAllOrder()
        {
            using (var connection=new SqlConnection(_connectionString))
            {
               var sqlQuery = "select *from Orders";
               return connection.Query<Orders>(sqlQuery);
               
            }
        }

        public Orders GetByOrderId(int Id)
        {
            using(var connection=new SqlConnection(_connectionString))
            {
                var sqlQuery = "select *from Orders where OrderID=@OrderID";
                return connection.QueryFirstOrDefault<Orders>(sqlQuery, new { OrderID = Id });
            }
        }

        public void Update(Orders orders)
        {
            using(var connection=new SqlConnection(_connectionString))
            {
                var sqlQuery = "update Orders set OrderID=@OrderID, CustomerID=@CustomerID,EmployeeID=@EmployeeID,OrderDate=@OrderDate,ShipperID=@ShipperID where OrderID=@OrderID ";
                connection.Query(sqlQuery,orders);
            }
        }
    }
}
