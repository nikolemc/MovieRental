using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MovieRental.Models
{
    public class Genres
    {
        public int Id { get; set; }
        public string Genre { get; set; }

        public Genres() { }
        public Genres(SqlDataReader reader)
        {
            this.Id = (int)reader["Id"];
            this.Genre = reader["Genre"]?.ToString();

        }
    }
}