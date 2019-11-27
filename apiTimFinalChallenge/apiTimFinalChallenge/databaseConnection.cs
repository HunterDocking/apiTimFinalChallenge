using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace apiTimFinalChallenge
{
    public static class databaseConnection
    {
        public static SqlConnection GetConnection()
        {
            string ConnectionString = @"Server=tcp:civapi.database.windows.net,1433;Initial Catalog=civapi;User ID=civ_user;Password=Monday1330;";
            return new SqlConnection(ConnectionString);
        }
    }
}