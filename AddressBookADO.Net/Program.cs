using System;

namespace AddressBookADO.Net
{
    class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Welcome to AddressBookADO.Net!");
            ///Creating Instance object of AddressBookRepository class.
            AddressBookRepository repository = new AddressBookRepository();
            ///UC1 Creating a method for checking for the validity of the connection.
            repository.EnsureDataBaseConnection();
            /// UC2 Getting all the stored records in the address book service table by fetching all the records
            repository.GetAllContact();
            /// UC 3: Adds the new contact into DB table.
            AddNewContactDetails();
            /// UC 4 Ability to Edit the contactType of the existing contact.
            Console.WriteLine(repository.EditContactUsingName("Daksha", "Neel", "Friend") ? "Update done successfully\n" : "Update failed");
            /// UC5 Ability to  Deletes the contact with given first name and last name.
            Console.WriteLine(repository.DeleteContact("Daksha", "Neel") ? "Deleted Contact successfully\n" : "Update failed");
        }


        /// <summary>
        /// Adds the new contact details.
        /// </summary>
        /// UC 3: Adds the new contact into DB table
        public static void AddNewContactDetails()
        {
            AddressBookRepository repository = new AddressBookRepository();
            AddressBookModel model = new AddressBookModel();
            model.FirstName = "Daksha";
            model.LastName = "Neel";
            model.Address = "Sadashivanagar";
            model.City = "Bnagalore";
            model.State = "Karnataka";
            model.Zip = 788776;
            model.PhoneNumber = 887788779;
            model.EmailId = "daksh@gmail.com";
            model.AddressBookName = "neha";
            model.AddressBookType = "Friend";
            Console.WriteLine(repository.AddDataToTable(model) ? "Record inserted successfully\n" : "Failed");
        }
    }
}