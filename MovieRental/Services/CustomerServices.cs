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

        public void UpdateCustomer(Customers revisedCustomer)
        {
            using (var connection = new SqlConnection(connectionString))
            {

                var updateCustomer = @"UPDATE [dbo].[CustomerTable] SET [Name] = @Name
                                                         ,[Email] = @Email
                                                         ,[PhoneNumber] = @PhoneNumber
                                                          WHERE Id = @Id";

                var sqlCommand = new SqlCommand(updateCustomer, connection);

                sqlCommand.Parameters.AddWithValue("@Id", revisedCustomer.Id);
                sqlCommand.Parameters.AddWithValue("@Name", revisedCustomer.Name);
                sqlCommand.Parameters.AddWithValue("@Email", revisedCustomer.Email);
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", revisedCustomer.PhoneNumber);

                connection.Open();
                sqlCommand.ExecuteNonQuery();
                connection.Close();
            }

        }

        public Customers GetCustomer(int id)
        {
            var rv = new Customers();
            using (var connection = new SqlConnection(connectionString))
            {

                var updatedCustomer = @"SELECT * FROM CustomerTable WHERE @Id = Id;";

                var sqlCommand = new SqlCommand(updatedCustomer, connection);
                sqlCommand.Parameters.AddWithValue("@Id", id);

                connection.Open();
                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    rv = new Customers(reader);
                }
                connection.Close();

            }
            return rv;

        }
    }
}