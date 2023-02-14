using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        /// <summary>
        /// Adds a Customer to the database
        /// </summary>
        /// <param name="c">The Customer to be added</param>
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

        /// <summary>
        /// Updates a Customer
        /// </summary>
        /// <param name="c">Customer to be updated</param>
        /// <exception cref="ArgumentException">Thrown if Customer does not exist</exception>
        public static void Update(Customer c)
        {
            // establish connection to database
            using SqlConnection con = DBHelper.GetDatabaseConnection("BookRegistration");

            // prepare insert statement
            SqlCommand updateCmd = new SqlCommand();
            updateCmd.Connection = con;
            // parameterize query
            updateCmd.CommandText = "UPDATE Customer " +
                                    "SET DateOfBirth = @dob " +
                                    " , FirstName = @firstName " +
                                    " , LastName = @lastName " +
                                    " , Title = @title " +
                                    "WHERE CustomerID = @customerId";
            updateCmd.Parameters.AddWithValue("@dob", c.DateOfBirth);
            updateCmd.Parameters.AddWithValue("@firstName", c.FirstName);
            updateCmd.Parameters.AddWithValue("@lastName", c.LastName);
            updateCmd.Parameters.AddWithValue("@title", c.Title);
            updateCmd.Parameters.AddWithValue("@customerId", c.CustomerID);

            // open connection to the database
            con.Open();

            // execute query
            int rows = updateCmd.ExecuteNonQuery();
            if (rows == 0)
            {
                throw new ArgumentException("A Customer with that Id does not exist!");
            }
        }
    }
}
