using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MovieRental.Models
{
    public class Movies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public int GenreId { get; set; }
        public int YearReleased { get; set; }
        public bool? IsCheckedOut { get; set; } = false;

        public Movies() { }
        public Movies(SqlDataReader reader)
        {
            this.Id = (int)reader["Id"];
            this.Name = reader["Name"]?.ToString();
            this.Director = reader["Director"]?.ToString();
            this.GenreId = (int)reader["GenreId"];
            this.YearReleased = (int)reader["YearReleased"];
            this.IsCheckedOut = (bool?)reader["IsCheckedOut"];

        }
    }
}