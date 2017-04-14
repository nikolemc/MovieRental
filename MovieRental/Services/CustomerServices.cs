using MovieRental.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MovieRental.ViewModel;

namespace MovieRental.Services
{
    public class CustomerServices
    {

        const string connectionString = @"Server=localhost\SQLEXPRESS;Database=MovieRentalData;Trusted_Connection=True;";

        public List<Customers> GetAllCustomers()
        {
            var rv = new List<Customers>();
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "SELECT * FROM [CustomerTable]";
                var cmd = new SqlCommand(query, connection);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rv.Add(new Customers(reader));
                }
                connection.Close();
            }
            return rv;

        }

        public void AddCustomer(Customers customers)
        {
            using (var connection = new SqlConnection(connectionString))
            {

                var newcustomer = @"INSERT INTO CustomerTable (Name, Email, PhoneNumber)" +
                "Values (@Name, @Email, @PhoneNumber)";

                var sqlCommand = new SqlCommand(newcustomer, connection);

                sqlCommand.Parameters.AddWithValue("@Name", customers.Name);
                sqlCommand.Parameters.AddWithValue("@Email", customers.Email);
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", customers.PhoneNumber);
                connection.Open();
                sqlCommand.ExecuteNonQuery();
                connection.Close();
                
            }

        }
    }
}