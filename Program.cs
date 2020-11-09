using System;

namespace AddressBookAdo.net
{
    class Program
    {
        static void Main(string[] args)
        {

            AddressBookRepository.EditContactUsingName("Akash", "Singh", "40/879");
            AddressBookRepository.GetAllContacts();
        }
    }
}
