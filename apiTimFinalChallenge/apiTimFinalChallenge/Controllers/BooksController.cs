using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using apiTimFinalChallenge.Models;

namespace apiTimFinalChallenge.Controllers
{
    public class BooksController : ApiController
    {
        // GET: api/Books
        public IEnumerable<BookModels> Get()
        {
            SqlConnection connection = databaseConnection.GetConnection();

            SqlCommand command;
            SqlDataReader reader;

            string query;
            List<BookModels> output = new List<BookModels>();

            try
            {
                connection.Open();

                query = "select isbn, title from Books";
                command = new SqlCommand(query, connection);



                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    output.Add(new BookModels(Int32.Parse(reader["isbn"].ToString()),
                    reader["title"].ToString()));
                }
            }

            catch (Exception e)
            {
                output.Clear();
                throw e;
            }

            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }

            }

            connection.Close();
            return output;
        }



        // GET: api/Books/5
        public IEnumerable<BookModels> Get(int id)
        {
            SqlConnection connection = databaseConnection.GetConnection();

            SqlCommand command;
            SqlDataReader reader;

            string query;
            List<BookModels> output = new List<BookModels>();

            try
            {
                connection.Open();

                query = "select * from Books where borrower = " + id;
                command = new SqlCommand(query, connection);



                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    output.Add(new BookModels(Int32.Parse(reader["isbn"].ToString()),
                    reader["title"].ToString()));
                }
            }

            catch (Exception e)
            {
                output.Clear();
                throw e;
            }

            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }

            }

            connection.Close();
            return output;
        }






        // POST: api/Books
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Books/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Books/5
        public void Delete(int id)
        {
        }
    }
}
