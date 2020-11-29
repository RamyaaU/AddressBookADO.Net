using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookADO.Net
{
    public class DBConnection
    {
        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <returns></returns>
        public SqlConnection GetConnection()
        {
            /// Specifying the connectionString from the sql server connection.
            string connectiongString = @"Data Source=RAMYA\SQLEXPRESS;Initial Catalog=addressbook_service;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectiongString);
            return connection;
        }
    }
}

