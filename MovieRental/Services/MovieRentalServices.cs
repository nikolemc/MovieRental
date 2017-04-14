using MovieRental.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MovieRental.ViewModel;

namespace MovieRental.Services
{
    public class MovieRentalServices
    {
        const string connectionString = @"Server=localhost\SQLEXPRESS;Database=MovieRentalData;Trusted_Connection=True;";
        public List<Movies> GetAllMovies()
        {
            var rv = new List<Movies>();
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "SELECT [MovieTable].[Id],[Name],[YearReleased],[Director], [GENRE], [IsCheckedOut] FROM [MovieTable] JOIN GenreTable ON MovieTable.Id = GenreTable.Id";
                var cmd = new SqlCommand(query, connection);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rv.Add(new Movies(reader));
                }
                connection.Close();
            }
            return rv;

        }

        public List<MovieGenreVM> GetAllMovieWithGenre()
        {
            var rv = new List<MovieGenreVM>();
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "SELECT [MovieTable].[Id],[Name],[YearReleased],[Director], [GENRE], [IsCheckedOut] FROM [MovieTable] JOIN GenreTable ON MovieTable.Id = GenreTable.Id";
                var cmd = new SqlCommand(query, connection);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rv.Add(new MovieGenreVM(reader));
                }
                connection.Close();
            }
            return rv;

        }
    }
}