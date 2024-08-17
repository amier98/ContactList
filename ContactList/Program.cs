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

            while (true)
            {
                Console.WriteLine("1: Add contact");
                Console.WriteLine("2: View contacts");
                Console.WriteLine("3: Edit contacts");
                Console.WriteLine("4: Delete contacts");

                var option = Console.ReadLine();    

                switch(option)
                {
                    case "1":
                        AddContact(contactManager);
                        break; 
                    case "2":
                        GetAllContacts(contactManager);
                        break;
                    case "3":
                        UpdateContact(contactManager);
                        break;
                    case "4":
                        DeleteContact(contactManager);
                        break;

                }
            }   
        }

        private static void DeleteContact(ContactManager contactManager)
        {
            Console.WriteLine("Enter Id of contact you want to delete: ");
            var contactId = Console.ReadLine();

            if (int.TryParse(contactId, out int id))
            { 

            contactManager.DeleteContact(id);
            }
        }

        private static void UpdateContact(ContactManager contactManager)
        {
            Console.WriteLine("Enter id of contact to update: ");
            var contactId = Console.ReadLine();

            if (int.TryParse(contactId, out int id))
            {
                var contact = contactManager.GetContactById(id);

                if (contact != null)

                Console.WriteLine("Edit Name: ");
                contact.Name = Console.ReadLine();
                Console.WriteLine("Edit Number: ");
                contact.Phone = Console.ReadLine();

                contactManager.UpdateContact(contact);
            }
        }

        public static void AddContact(ContactManager contactManager)
        {
            Contact contact = new Contact();

            Console.WriteLine("Add Contact Name");
            contact.Name = Console.ReadLine();
            Console.WriteLine("Add Phone Nummber");
            contact.Phone = Console.ReadLine();

            contactManager.AddContact(contact);
            Console.WriteLine(contact.Id);
        }

        public static void GetAllContacts(ContactManager contactManager)
        {
            var contacts = contactManager.GetContacts();

            foreach (var contact in contacts)
            {
                Console.WriteLine(contact.Name);
            }
        }

    }
}
