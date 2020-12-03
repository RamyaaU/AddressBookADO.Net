using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookADO.Net
{
    public class AddressBookRepository
    {
        private static string connectionString = @"Data Source=RAMYA\SQLEXPRESS;Initial Catalog=Address_Book_Service;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);

        /// <summary>
        /// UC16
        /// Gets all contacts.
        /// </summary>
        /// <exception cref="System.Exception"></exception>
        public void GetAllContacts()
        {
            try
            {
                AddressBookModel model = new AddressBookModel();
                using (this.connection)
                {
                    string query = "Select * from New_Address_Book";
                    SqlCommand command = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            model.ContactId = reader.GetInt32(0);
                            model.FirstName = reader.GetString(1);
                            model.LastName = reader.GetString(2);
                            model.Address = reader.GetString(3);
                            model.City = reader.GetString(4);
                            model.State = reader.GetString(5);
                            model.Zip = reader.GetInt32(6);
                            model.PhoneNumber = reader.GetString(7);
                            model.Email = reader.GetString(8);

                            Console.WriteLine(model.ContactId + "\t" + model.FirstName + "\t" + model.LastName + "\t" + model.Address + "\t"
                                + model.City + "\t" + model.State + "\t" + model.Zip + "\t" + model.PhoneNumber + "\t" + model.Email);

                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Data Not Found");
                    }
                    reader.Close();
                    this.connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// UC17
        /// Updates the contact table.
        /// </summary>
        /// <returns></returns>
        public bool UpdateContactTable()
        {
            try
            {
                string query = @"update New_Address_Book set Address = 'Nizamabad' , City = 'Hyderabad' where  Id = 3";
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// UC18
        /// Retrieves the contact within date range.
        /// </summary>
        public void RetrieveContactWithinDateRange()
        {
            try
            {
                AddressBookModel model = new AddressBookModel();
                using (this.connection)
                {
                    string query = @"select * from New_Address_Book  
                    where  AddedDate between cast('01-01-2019' as date) and SYSDATETIME();";

                    SqlCommand command = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            model.ContactId = reader.GetInt32(0);
                            model.FirstName = reader.GetString(1);
                            model.LastName = reader.GetString(2);
                            model.Address = reader.GetString(3);
                            model.City = reader.GetString(4);
                            model.State = reader.GetString(5);
                            model.Zip = reader.GetInt32(6);
                            model.PhoneNumber = reader.GetString(7);
                            model.Email = reader.GetString(8);
                            model.AddedDate = reader.GetDateTime(9);

                            Console.WriteLine(model.ContactId + "\t" + model.FirstName + "\t" + model.LastName + "\t" + model.Address + "\t"
                                + model.City + "\t" + model.State + "\t" + model.Zip + "\t" + model.PhoneNumber + "\t" + model.Email + "\t"
                                + model.AddedDate);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    reader.Close();
                    this.connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// UC19
        /// Retrieves the contact by city.
        /// </summary>
        /// <exception cref="System.Exception"></exception>
        public void RetrieveContactByCity()
        {
            try
            {
                AddressBookModel model = new AddressBookModel();
                using (this.connection)
                {
                    string query = @"select * from New_Address_Book where City = 'Bangalore';";

                    SqlCommand command = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            model.ContactId = reader.GetInt32(0);
                            model.FirstName = reader.GetString(1);
                            model.LastName = reader.GetString(2);
                            model.Address = reader.GetString(3);
                            model.City = reader.GetString(4);
                            model.State = reader.GetString(5);
                            model.Zip = reader.GetInt32(6);
                            model.PhoneNumber = reader.GetString(7);
                            model.Email = reader.GetString(8);
                            model.AddedDate = reader.GetDateTime(9);

                            Console.WriteLine(model.ContactId + "\t" + model.FirstName + "\t" + model.LastName + "\t" + model.Address + "\t"
                                + model.City + "\t" + model.State + "\t" + model.Zip + "\t" + model.PhoneNumber + "\t" + model.Email + "\t"
                                + model.AddedDate);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    reader.Close();
                    this.connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// Adds the contact to database.
        /// </summary>
        /// <param name="model">The model.</param>
        public bool AddContactToDatabase(AddressBookModel model)
        {
            try
            {
                using (this.connection)
                {
                    // Created instance of the given query and connection
                    SqlCommand command = new SqlCommand("spAddContact", this.connection);
                    // Command type  as text for stored procedure
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    // Adds the values to the stored procedure

                    command.Parameters.AddWithValue("@First_Name", model.FirstName);
                    command.Parameters.AddWithValue("@Last_Name", model.LastName);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@City", model.City);
                    command.Parameters.AddWithValue("@State", model.State);
                    command.Parameters.AddWithValue("@Zip", model.Zip);
                    command.Parameters.AddWithValue("@Phone_Number", model.PhoneNumber);
                    command.Parameters.AddWithValue("@Email", model.Email);
                    command.Parameters.AddWithValue("@AddedDate", model.AddedDate);

                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    this.connection.Close();

                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
            return false;
        }
    }
}

  