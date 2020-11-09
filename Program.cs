using System;

namespace AddressBookAdo.net
{
    class Program
    {
        static void Main(string[] args)
        {

            AddressBookRepository.DeleteContact("Naveen", "Gupt");

            AddressBookRepository.GetAllContacts();
        }
    }
}
