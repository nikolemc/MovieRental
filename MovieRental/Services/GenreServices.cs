using MovieRental.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MovieRental.ViewModel;

namespace MovieRental.Services
{
    public class GenreServices
    {
        const string connectionString = @"Server=localhost\SQLEXPRESS;Database=MovieRentalData;Trusted_Connection=True;";

        public List<Genres> GetAllGenres()
        {
            var rv = new List<Genres>();
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "SELECT * FROM [GenreTable]";
                var cmd = new SqlCommand(query, connection);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rv.Add(new Genres(reader));
                }
                connection.Close();
            }
            return rv;

        }

        public void AddGenre(Genres genres)
        {
            using (var connection = new SqlConnection(connectionString))
            {

                var newgenre = @"INSERT INTO GenreTable (Genre)" +
                "Values (@Genre)";

                var sqlCommand = new SqlCommand(newgenre, connection);

                sqlCommand.Parameters.AddWithValue("@Genre", genres.Genre);
                connection.Open();
                sqlCommand.ExecuteNonQuery();
                connection.Close();

            }

        }

        public void UpdateGenre(Genres revisedGenre)
        {
            using (var connection = new SqlConnection(connectionString))
            {

                var updateCustomer = @"UPDATE [dbo].[GenreTable] SET [Genre] = @Genre WHERE Id = @Id";

                var sqlCommand = new SqlCommand(updateCustomer, connection);

                sqlCommand.Parameters.AddWithValue("@Id", revisedGenre.Id);
                sqlCommand.Parameters.AddWithValue("@Genre", revisedGenre.Genre);

                connection.Open();
                sqlCommand.ExecuteNonQuery();
                connection.Close();
            }

        }

        public Genres GetGenre(int id)
        {
            var rv = new Genres();
            using (var connection = new SqlConnection(connectionString))
            {

                var updatedGenre = @"SELECT * FROM GenreTable WHERE @Id = Id;";

                var sqlCommand = new SqlCommand(updatedGenre, connection);
                sqlCommand.Parameters.AddWithValue("@Id", id);

                connection.Open();
                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    rv = new Genres(reader);
                }
                connection.Close();

            }
            return rv;

        }

    }
}