using MovieRental.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MovieRental.ViewModel;


namespace MovieRental.Services
{
    public class RentalRecordsServices
    {
        const string connectionString = @"Server=localhost\SQLEXPRESS;Database=MovieRentalData;Trusted_Connection=True;";

        public List<RentalRecords> GetAllRentalRecords()
        {
            var rv = new List<RentalRecords>();
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "SELECT * FROM [RentalLogTable]";
                var cmd = new SqlCommand(query, connection);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rv.Add(new RentalRecords(reader));
                }
                connection.Close();
            }
            return rv;

        }


        public List<MoviesOverDueContactVM> GetAllRentalRecordsWithContacts()
        {
            var rv = new List<MoviesOverDueContactVM>();
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "SELECT r1.DateCheckedOut, r1.DueDate, m1.[Name] as Movie_Name, c1.[Name] as Customer_Name, c1.Email as Customer_Email, c1.PhoneNumber as PhoneNumber" +
                            " FROM dbo.RentalLogTable as r1" +
                            " LEFT JOIN dbo.MovieTable m1 on r1.MovieID = m1.Id" +
                            " LEFT JOIN dbo.CustomerTable c1 on r1.CustomerID = c1.Id" +
                            " WHERE r1.DueDate < getdate()";
                var cmd = new SqlCommand(query, connection);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rv.Add(new MoviesOverDueContactVM(reader));
                }
                connection.Close();
            }
            return rv;

        }

        public void AddRentalRecords(RentalRecords RentalRecord)
        {
            using (var connection = new SqlConnection(connectionString))
            {

                var newRentalRecord = @"INSERT INTO RentalLogTable (CustomerId, MovieId, DateCheckedOut, DueDate)" +
                "Values (@CustomerId, @MovieId, @DateCheckedOut, @DueDate)";

                var sqlCommand = new SqlCommand(newRentalRecord, connection);

                sqlCommand.Parameters.AddWithValue("@CustomerId", RentalRecord.CustomerId);
                sqlCommand.Parameters.AddWithValue("@MovieId", RentalRecord.MovieId);
                sqlCommand.Parameters.AddWithValue("@DateCheckedOut", RentalRecord.DateCheckedOut);
                sqlCommand.Parameters.AddWithValue("@DueDate", RentalRecord.DueDate);

                connection.Open();
                sqlCommand.ExecuteNonQuery();
                connection.Close();


            }


        }


    }
}