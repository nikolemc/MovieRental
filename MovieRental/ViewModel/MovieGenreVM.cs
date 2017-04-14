using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MovieRental.ViewModel
{
    public class MovieGenreVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public int YearReleased { get; set; }
        public bool? IsCheckedOut { get; set; } = false;
        public string Genre { get; set; }

        public MovieGenreVM() { }
        public MovieGenreVM(SqlDataReader reader)
        {
            this.Id = (int)reader["Id"];
            this.Name = reader["Director"]?.ToString();
            this.Director = reader["Name"]?.ToString();
            this.Genre = reader["Genre"]?.ToString();
            this.YearReleased = (int)reader["YearReleased"];
            this.IsCheckedOut = (bool?)reader["IsCheckedOut"];

        }
    }
}