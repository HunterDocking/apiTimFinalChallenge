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
    public class BorrowerController : ApiController
    {
        // GET: api/Borrower
        public IEnumerable<BorrowerModels> Get()
        {
            SqlConnection connection = databaseConnection.GetConnection();

            SqlCommand command;
            SqlDataReader reader;

            string query;
            List<BorrowerModels> output = new List<BorrowerModels>();

            try
            {
                connection.Open();

                query = "select * from Borrower";
                command = new SqlCommand(query, connection);



                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    output.Add(new BorrowerModels(Int32.Parse(reader["id"].ToString()),
                        reader["surname"].ToString(),
                        reader["firstname"].ToString(),
                        reader["DOB"].ToString()));
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


        // GET: api/Borrower/5
        // GET: api/Books/5
        public string Get(int id)
        {
            return "value";
        }




        // POST: api/Borrower
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Borrower/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Borrower/5
        public void Delete(int id)
        {
        }
    }
}
