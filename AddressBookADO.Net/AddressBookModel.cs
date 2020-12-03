using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookADO.Net
{
    /// <summary>
    /// Class to map the relational data base model to a entity.
    /// </summary>

    public class AddressBookModel
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BookName { get; set; }
        public int TypeId { get; set; }
        public string Type { get; set; }
        public int BookId { get; set; }
    }
}
