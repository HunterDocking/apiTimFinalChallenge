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
    public class NotBorrowedController : ApiController
    {
        // GET: api/NotBorrowed
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

                query = "select * from Books where borrower is null";
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

        // GET: api/NotBorrowed/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/NotBorrowed
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/NotBorrowed/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/NotBorrowed/5
        public void Delete(int id)
        {
        }
    }
}
