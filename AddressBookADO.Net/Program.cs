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
            AddressBookRepository addressBookRepo = new AddressBookRepository();
            addressBookRepo.RetrieveContactWithinDateRange();
        }
    }
}