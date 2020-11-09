using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookAdo.net
{
    public class DBConnection
    {
        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <returns><Sqlconnection>
        public SqlConnection GetConnection()
        {
            //Initialising the connection string 
            string con  = @"Data Source=LAPTOP-V5IRNHKS\SQLEXPRESS;Initial Catalog=address_book;User ID=akash;Password=akash2507;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new SqlConnection(con);
            return connection;
        }
    }
}
