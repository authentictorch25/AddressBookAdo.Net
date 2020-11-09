using System;

namespace AddressBookAdo.net
{
    class Program
    {
        static void Main(string[] args)
        {
           
            AddressBookModel model = new AddressBookModel();
            model.firstName = "Naveen";
            model.lastName = "Gupt";
            model.address = "40/458";
            model.city = "Gorakhpur";
            model.state = "UttarPradesh";
            model.zip = 458958;
            model.phoneNumber = 9587685632;
            model.addressBookName = "frquent";
            model.contactType = "friends";
            model.email = "naveen@gmail.com";

            AddressBookRepository.AddContact(model);
            AddressBookRepository.GetAllContacts();
        }
    }
}
