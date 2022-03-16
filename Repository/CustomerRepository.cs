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
    public class CustomerRepository : ICustomer
    {
        private readonly string _connectionString;
        public CustomerRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlConcept");
        }

        public async Task<Customer> Create(Customer customer)
        {
            var sqlQuery = "INSERT INTO Customers(CustomerID, CustomerName, ContactName,Address,City,PostalCode,Country) VALUES (@CustomerID, @CustomerName, @ContactName,@Address,@City,@PostalCode,@Country)";
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(sqlQuery, new
                {
                    customer.CustomerID,
                    customer.CustomerName,
                    customer.ContactName,
                    customer.Address,
                    customer.City,
                    customer.PostalCode,
                    customer.Country
                });

                return customer;

            }
        }

        public async Task Delete(int id)
        {
            var sqlQuery = "DELETE from Customers where CustomerID =@CustomerID";

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(sqlQuery, new { CustomerID = id });
            }
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            var sqlQuery = "select *from Customers";

            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync<Customer>(sqlQuery);
            }
        }

        public async Task<Customer> GetById(int id)
        {
            var sqlQuery = "select *from Customers where CustomerID=@CustomerID";
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<Customer>(sqlQuery,new { CustomerID = id});
            }
        }

        public async Task Update(Customer customer)
        {
            var sqlQuery = "UPDATE Customers SET CustomerID=@CustomerID, CustomerName=@CustomerName, ContactName=@ContactName,Address=@Address,City=@City,PostalCode=@PostalCode,Country=@Country WHERE CustomerID=@CustomerID";

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(sqlQuery, new
                {

                    customer.CustomerID,
                    customer.CustomerName,
                    customer.ContactName,
                    customer.Address,
                    customer.City,
                    customer.PostalCode,
                    customer.Country
                });
            }
        }
    }
}
