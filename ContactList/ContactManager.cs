using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList
{
    public class ContactManager : IContact
    {
        private readonly List<Contact> contacts = new List<Contact>();

        private int nextId = 1;

        public void AddContact(Contact contact)
        {
            contact.Id = nextId++;
            contacts.Add(contact);
        }

        public List<Contact> GetContacts()
        {
            return contacts;
        }

        public Contact GetContactById(int id)
        {
            return contacts.FirstOrDefault(c => c.Id == id);
        }

        public void UpdateContact(Contact contact) 
        { 
            var exisitingContact =  GetContactById(contact.Id);

            if (exisitingContact != null)
            {
                exisitingContact.Name = contact.Name;
                exisitingContact.Address = contact.Address;
                exisitingContact.Phone = contact.Phone;
                exisitingContact.BirthDate = contact.BirthDate;
            }
        }

        public void DeleteContact(int id)
        {
            var existingContact = GetContactById(id);

            contacts.Remove(existingContact);
        }
    }
}
