using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace MovieRental.Models
{
    public class RentalRecords
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
        public DateTime? DateCheckedOut { get; set; }
        public DateTime? DueDate { get; set; }

        public RentalRecords() { }
        public RentalRecords(SqlDataReader reader)
        {
            this.Id = (int)reader["Id"];
            this.CustomerId = (int)reader["CustomerId"];
            this.MovieId = (int)reader["MovieId"];
            this.DateCheckedOut = (DateTime?)reader["DateCheckedOut"];
            this.DueDate = (DateTime?)reader["DueDate"];
           

        }
    }
}