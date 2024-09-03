using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList
{
    public class ContactService 
    {
        private readonly IContact _contactManager;

        public ContactService(IContact contactManager)
        {
            _contactManager = contactManager;
        }

        public void DeleteContact()
        {
            Console.WriteLine("Enter Id of contact you want to delete: ");
            var contactId = Console.ReadLine();

            if (int.TryParse(contactId, out int id))
            {
                var contact = _contactManager.GetContactById(id);


                if (contact != null)
                {
                    _contactManager.DeleteContact(id);
                }
                else
                {
                    Console.WriteLine("Contact does not exist");
                }
            }
            else
            {
                // terrible message, i know haha
                Console.WriteLine("Not correct id");
            }
        }

        public void UpdateContact()
        {
            Console.WriteLine("Enter id of contact to update: ");
            var contactId = Console.ReadLine();

            if (int.TryParse(contactId, out int id))
            {
                var contact = _contactManager.GetContactById(id);

                if (contact != null)
                {

                    Console.WriteLine("Edit Name: ");
                    contact.Name = Console.ReadLine();
                    Console.WriteLine("Edit Number: ");
                    contact.Phone = Console.ReadLine();

                    _contactManager.UpdateContact(contact);

                }
                else
                {
                    Console.WriteLine("Contact does not exist!");
                }
            }
            else
            {
                Console.WriteLine("id does not exist");
            }
        }

        public void AddContact()
        {
            Contact contact = new Contact();

            while (true)
            {

                Console.WriteLine("Add Contact Name");

                contact.Name = Console.ReadLine();

                if (string.IsNullOrEmpty(contact.Name))
                {
                    Console.WriteLine("Field must have a value!");
                }
                else
                {
                    break;
                }

            }

            while (true)
            {
                Console.WriteLine("Add Phone Nummber");

                contact.Phone = Console.ReadLine();

                if (string.IsNullOrEmpty(contact.Phone))
                {
                    Console.WriteLine("field must have a value");
                }
                else
                {
                    break;
                }
            }

            _contactManager.AddContact(contact);
            Console.WriteLine("");
            Console.WriteLine("Congratulations!, you have added a new contact");
            Console.WriteLine($"Contact id: {contact.Id}");

        }

        public void GetAllContacts()
        {
            var contacts = _contactManager.GetContacts();

            foreach (var contact in contacts)
            {
                Console.WriteLine(contact.Name);
            }
        }
    }
}
