using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookAdo.net
{
    public class AddressBookRepository
    {
         public static SqlConnection connection { get; set; }

        public static void GetAllContacts()
        {
            //Creates a new connection for every method to avoid "ConnectionString property not initialized" exception
            DBConnection dbc = new DBConnection();
            connection = dbc.GetConnection();
            AddressBookModel model = new AddressBookModel();
            string query = @"select * from dbo.AddressBook";
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            model.firstName = reader.GetString(0);
                            model.lastName = reader.GetString(1);
                            model.address = reader.GetString(2);
                            model.city = reader.GetString(3);
                            model.state = reader.GetString(4);
                            model.zip = reader.GetInt64(5);
                            model.phoneNumber = reader.GetInt64(6);
                            model.email = reader.GetString(7);
                            model.addressBookName = reader.GetString(8);
                            model.contactType = reader.GetString(9);
                            Console.WriteLine($"First Name: {model.firstName}\nLast Name: {model.lastName}\nAddress: {model.address}\nCity: {model.city}\nState: {model.state}\nZip: {model.zip}\nPhone Number: {model.phoneNumber}\nEmail: {model.email}\nContact Type: {model.contactType}\nAddress Book Name : {model.addressBookName}");
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (connection.State.Equals("Open"))
                    connection.Close();
            }
        }
    }
}
