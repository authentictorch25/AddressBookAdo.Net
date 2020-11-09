using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookAdo.net
{
    /// <summary>
    /// Creating the model to map with the details of the address book
    /// </summary>
    public class AddressBookModel
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public double zip { get; set; }
        public double phoneNumber { get; set; }
        public string email { get; set; }
        public string contactType { get; set; }
        public string addressBookName { get; set; }
    }
}
