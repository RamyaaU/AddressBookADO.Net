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
            repository.EnsureDataBaseConnection();
            /// UC2 Getting all the stored records in the address book service table by fetching all the records
            repository.GetAllContact();
            /// UC 3: Adds the new contact into DB table.
            AddNewContactDetails();
        }
        /// UC 3: Adds the new contact into DB table.
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
