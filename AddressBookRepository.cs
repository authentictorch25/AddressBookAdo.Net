using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookAdo.net
{
    public class AddressBookRepository
    {
        //Initialising connection variable to store connection for each function
        public static SqlConnection connection { get; set; }
        /// <summary>
        /// Gets all contacts.
        /// </summary>
        /// <exception cref="Exception"></exception>
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
        /// <summary>
        /// Adds the contact.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool AddContact(AddressBookModel model)
        {
            DBConnection dbc = new DBConnection();
            connection = dbc.GetConnection();
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("dbo.spAddContactDetails", connection);
                    //To execute stored procedure convrting to commandtext
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@firstname", model.firstName);
                    command.Parameters.AddWithValue("@lastname", model.lastName);
                    command.Parameters.AddWithValue("@address", model.address);
                    command.Parameters.AddWithValue("@city", model.city);
                    command.Parameters.AddWithValue("@state", model.state);
                    command.Parameters.AddWithValue("@zip", model.zip);
                    command.Parameters.AddWithValue("@phoneNo", model.phoneNumber);
                    command.Parameters.AddWithValue("@email", model.email);
                    command.Parameters.AddWithValue("@addressbookname", model.addressBookName);
                    command.Parameters.AddWithValue("@contactType", model.contactType);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
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
        /// <summary>
        /// Edits the name of the contact using.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="address">The address.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool EditContactUsingName(string firstName, string lastName, string address)
        {
            DBConnection dbc = new DBConnection();
            connection = dbc.GetConnection();
            try
            {
                using (connection)
                {
                    connection.Open();
                    string query = $@"update dbo.AddressBook set address='{address}' where first_name='{firstName}' and last_name='{lastName}'";
                    SqlCommand command = new SqlCommand(query, connection);
                    var result = command.ExecuteNonQuery();
                    connection.Close();
                    if (result > 0)
                    {
                        return true;
                    }
                    return false;
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
        /// <summary>
        /// Deletes the contact.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool DeleteContact(string firstName, string lastName)
        {
            DBConnection dbc = new DBConnection();
            connection = dbc.GetConnection();
            try
            {
                using (connection)
                {
                    connection.Open();
                    string query = $@"delete from dbo.AddressBook where first_name='{firstName}' and last_name='{lastName}'";
                    SqlCommand command = new SqlCommand(query, connection);
                    var result = command.ExecuteNonQuery();
                    connection.Close();
                    if (result > 0)
                    {
                        return true;
                    }
                    return false;
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
        /// <summary>
        /// Retrieves the state of the contact from a city or.
        /// </summary>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <exception cref="Exception"></exception>
        public static void GetContactByCityOrState(string city, string state)
        {
            DBConnection dbc = new DBConnection();
            connection = dbc.GetConnection();
            AddressBookModel model = new AddressBookModel();
            string query = $@"select * from dbo.AddressBook where state='{state}' and city='{city}'";
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
        /// <summary>
        /// Gets the number of contact in city or state
        /// </summary>
        /// <exception cref="Exception"></exception>
        public static void GetCountOfContactInCityOrState()
        {
            Console.WriteLine("Enter:\n1.count by city\n2count by state");
            int choice = Convert.ToInt32(Console.ReadLine());
            string query;
            if (choice == 1)
            { query = $@"select city,count(city) as PeopleInCity from AddressBook group by City";}
            else
            { query = $@"select state,count(state) as PeopleInCity from AddressBook group by State"; }
            
            DBConnection dbc = new DBConnection();
            connection = dbc.GetConnection();
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
                            string CityorState = reader[0].ToString();
                            int count = reader.GetInt32(1);
                            Console.WriteLine($"City/State:{CityorState}\nnumOfContacts:{count}\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data found");
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
