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
            AddressBookRepository addressBookRepo = new AddressBookRepository();
            AddressBookModel model = new AddressBookModel();
            model.FirstName = "Ritu";
            model.LastName = "Verma";
            model.Address = "Nayandalli";
            model.City = "Mysore";
            model.State = "Karnataka";
            model.Zip = 598746;
            model.PhoneNumber = "9988776655";
            model.Email = "ritu@gmail.com";
            model.AddedDate = Convert.ToDateTime("08-08-2008");
        }
    }
}



