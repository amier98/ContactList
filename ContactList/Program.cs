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
                //might be worth adding a view contact (singular) option

                var option = Console.ReadLine();

                switch (option)
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
        // this whole block below should be in its own class. Its purpose is different to the program class. Think of the below as a Service and your ContactManager class as the Repository
        private static void DeleteContact(ContactManager contactManager)
        {
            Console.WriteLine("Enter Id of contact you want to delete: ");
            var contactId = Console.ReadLine();

            if (int.TryParse(contactId, out int id))
            {

                contactManager.DeleteContact(id);
                //You'll need some error handling for this in the case that the id doesn't exist
            }
            //You'll want an else block for when the tryParse fails. Maybe another message
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
            //You'll probably want validation for the below fields
            Console.WriteLine("Add Contact Name");
            contact.Name = Console.ReadLine();
            Console.WriteLine("Add Phone Nummber");
            contact.Phone = Console.ReadLine();

            contactManager.AddContact(contact);
            Console.WriteLine(contact.Id);
            // if you're going to display the id, you probably want it to be clear to the user that this is the id
        }

        public static void GetAllContacts(ContactManager contactManager)
        {
            var contacts = contactManager.GetContacts();

            foreach (var contact in contacts)
            {
                Console.WriteLine(contact.Name); // you probably want to include the id
            }
        }

    }
}
