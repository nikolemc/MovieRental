using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MovieRental.Models
{
    public class Customers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Customers() { }
        public Customers(SqlDataReader reader)
        {
            this.Id = (int)reader["Id"];
            this.Name = reader["Name"]?.ToString();
            this.Email = reader["Email"]?.ToString();
            this.PhoneNumber = reader["PhoneNumber"]?.ToString(); ;           

        }
    }
}