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
    public class BorrowedBookController : ApiController
    {
        // GET: api/Books
        public IEnumerable<BorrowedBookModels> Get()
        {
            SqlConnection connection = databaseConnection.GetConnection();

            SqlCommand command;
            SqlDataReader reader;

            string query;
            List<BorrowedBookModels> output = new List<BorrowedBookModels>();

            try
            {
                connection.Open();

                query = "select * " +
                    "from Books " +
                    "inner join Borrower on Books.Borrower = Borrower.id " +
                    "where Books.Borrower is not null";
                command = new SqlCommand(query, connection);



                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    output.Add(new BorrowedBookModels(Int32.Parse(reader["isbn"].ToString()),
                    Int32.Parse(reader["id"].ToString()),
                    reader["surname"].ToString(),
                    reader["firstname"].ToString(),
                    reader["DOB"].ToString(),
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

        // GET: api/BorrowedBook/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/BorrowedBook
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/BorrowedBook/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/BorrowedBook/5
        public void Delete(int id)
        {
        }
    }
}
