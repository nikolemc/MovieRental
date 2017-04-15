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

        public List<CheckedOutMoviesVM> CheckedOutMovies()
        {
            var rv = new List<CheckedOutMoviesVM>();
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "SELECT [MovieTable].[Id],[Name],[YearReleased],[Director], [GENRE], [IsCheckedOut] FROM [MovieTable] JOIN GenreTable ON MovieTable.Id = GenreTable.Id";
                var cmd = new SqlCommand(query, connection);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rv.Add(new CheckedOutMoviesVM(reader));
                }
                connection.Close();
            }
            return rv;

        }

        public void AddMovie(Movies movie)
        {
            using (var connection = new SqlConnection(connectionString))
            {

                var newmovie = @"INSERT INTO MovieTable (Name, GenreId, Director, YearReleased, IsCheckedOut)" +
                "Values (@Name, @GenreId, @Director, @YearReleased, @IsCheckedOut)";

                var sqlCommand = new SqlCommand(newmovie, connection);

                sqlCommand.Parameters.AddWithValue("@Name", movie.Name);
                sqlCommand.Parameters.AddWithValue("@GenreId", movie.GenreId);
                sqlCommand.Parameters.AddWithValue("@Director", movie.Director);
                sqlCommand.Parameters.AddWithValue("@YearReleased", movie.YearReleased);
                sqlCommand.Parameters.AddWithValue("@IsCheckedOut", movie.IsCheckedOut);

                connection.Open();
                sqlCommand.ExecuteNonQuery();
                connection.Close();


            }


        }

        public void UpdateMovie(Movies revisedMovie)
        {
            using (var connection = new SqlConnection(connectionString))
            {

                var updateMovie = @"UPDATE [dbo].[MovieTable] SET [Name] = @Name
                                                         ,[Director] = @Director
                                                         ,[GenreId] = @GenreId
                                                         ,[YearReleased] = @YearReleased
                                                         ,[IsCheckedOut] = @IsCheckedOut
                                                          WHERE Id = @Id";

                var sqlCommand = new SqlCommand(updateMovie, connection);

                sqlCommand.Parameters.AddWithValue("@Id", revisedMovie.Id);
                sqlCommand.Parameters.AddWithValue("@Name", revisedMovie.Name);
                sqlCommand.Parameters.AddWithValue("@Director", revisedMovie.Director);
                sqlCommand.Parameters.AddWithValue("@GenreId", revisedMovie.GenreId);
                sqlCommand.Parameters.AddWithValue("@YearReleased", revisedMovie.YearReleased);
                sqlCommand.Parameters.AddWithValue("@IsCheckedOut", revisedMovie.IsCheckedOut);

                connection.Open();
                sqlCommand.ExecuteNonQuery();
                connection.Close();

            }

        }

        public Movies GetMovie(int id)
        {
            var rv = new Movies();
            using (var connection = new SqlConnection(connectionString))
            {

                var updatedMovie = @"SELECT * FROM MovieTable WHERE @Id = Id;";

                var sqlCommand = new SqlCommand(updatedMovie, connection);
                sqlCommand.Parameters.AddWithValue("@Id", id);

                connection.Open();
                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    rv = new Movies(reader);
                }
                connection.Close();

            }
            return rv;

        }

        public Movies DeleteMovie(int id)
        {
            var rv = new Movies();
            using (var connection = new SqlConnection(connectionString))
            {
                //need to delete rental log
                var updatedMovieLog = @"DELETE FROM RentalLogTable WHERE @Id = MovieId;";

                var sqlCommand = new SqlCommand(updatedMovieLog, connection);
                sqlCommand.Parameters.AddWithValue("@Id", id);

                connection.Open();
                var reader = sqlCommand.ExecuteNonQuery();


                //then I can delete the movie
                var updatedMovie = @"DELETE FROM MovieTable WHERE @Id = Id;";

                var sqlCommand2 = new SqlCommand(updatedMovie, connection);
                sqlCommand2.Parameters.AddWithValue("@Id", id);

                sqlCommand2.ExecuteNonQuery();
                connection.Close();

            }
            return rv;


        }

        public static void MovieCheckOutStatus(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var openGift = @"UPDATE MovieTable SET IsCheckedOut = @IsOpened WHERE @Id = Id";
                var cmd = new SqlCommand(openGift, connection);
                cmd.Parameters.AddWithValue("@IsCheckedOut", true);
                cmd.Parameters.AddWithValue("@Id", id);

                connection.Open();
                var reader = cmd.ExecuteNonQuery();
                connection.Close();
            }

        }




    }

}
