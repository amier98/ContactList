using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ContactList
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            ContactManager contactManager = new ContactManager();
            ContactService contactService = new ContactService(contactManager);
            
            //moved all the logic into the service as you suggested, looks much cleaner now and I see the maintainability
            while (true)
            {
                Console.WriteLine("1: Add contact");
                Console.WriteLine("2: View contacts");
                Console.WriteLine("3: Edit contacts");
                Console.WriteLine("4: Delete contacts");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        contactService.AddContact(contactManager);
                        break;
                    case "2":
                        contactService.GetAllContacts(contactManager);
                        break;
                    case "3":
                        contactService.UpdateContact(contactManager);
                        break;
                    case "4":
                        contactService.DeleteContact(contactManager);
                        break;
                }
            }
        }
    }
}
