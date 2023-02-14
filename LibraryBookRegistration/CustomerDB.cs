using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBookRegistration
{
    /// <summary>
    /// Represents CRUD Functionality of Customer
    /// </summary>
    public class CustomerDB
    {
        public static void Add(Customer c)
        {
            // establish connection to database
            using SqlConnection con = DBHelper.GetDatabaseConnection("BookRegistration");

            // prepare insert statement
            SqlCommand insertCmd = new SqlCommand();
            insertCmd.Connection = con;
            // Parameterize query
            insertCmd.CommandText = "INSERT INTO Customer(DateOfBirth, FirstName, LastName, Title) " +
                                              "VALUES (@dob, @firstName, @lastName, @title)";
            insertCmd.Parameters.AddWithValue("@dob", c.DateOfBirth);
            insertCmd.Parameters.AddWithValue("@firstName", c.FirstName);
            insertCmd.Parameters.AddWithValue("@lastName", c.LastName);
            insertCmd.Parameters.AddWithValue("title", c.Title);

            // open connection to the database
            con.Open();

            // execute insert query
            insertCmd.ExecuteNonQuery();
        }
    }
}
