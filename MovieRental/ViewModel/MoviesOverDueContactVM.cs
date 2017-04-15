using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace MovieRental.ViewModel
{

    public class MoviesOverDueContactVM
    {

        public int Id { get; set; }
        public DateTime? DateCheckedOut { get; set; }
        public DateTime? DueDate { get; set; }
        public string Movie_Name { get; set; }
        public string Customer_Name { get; set; }
        public string Customer_Email { get; set; }
        public string PhoneNumber { get; set; }


        public string Due_Date
        {
            get
            {
                if (DueDate.HasValue)
                {
                    return ((DateTime)this.DueDate).ToShortDateString();

                }
                else
                {
                    return null;
                }
            }
        }

        public string Date_Checked_Out
        {
            get
            {
                if (DateCheckedOut.HasValue)
                {
                    return ((DateTime)this.DateCheckedOut).ToShortDateString();

                }
                else
                {
                    return null;
                }
            }
        }

        public MoviesOverDueContactVM() { }
        public MoviesOverDueContactVM(SqlDataReader reader)
        {
            //this.Id = (int)reader["Id"];
            this.DateCheckedOut = (DateTime)reader["DateCheckedOut"];
            this.DueDate = (DateTime)reader["DueDate"];
            this.Movie_Name = reader["Movie_Name"]?.ToString();
            this.Customer_Name = reader["Customer_Name"]?.ToString();
            this.Customer_Email = reader["Customer_Email"]?.ToString();
            this.PhoneNumber = reader["PhoneNumber"]?.ToString();

        }

       
    }
}