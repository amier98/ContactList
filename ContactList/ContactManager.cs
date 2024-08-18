using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList
{
    public class ContactManager // Don't forget the interface :)
    {
        private List<Contact> contacts = new List<Contact>(); // contacts should be readonly in any case, as it cannot be changed, which helps to maintain consistency and prevent unintended modifications throughout the life of an object
        /*
        You likely don't want to do what you've done on the above line. It'd be better to create the Contact List in your Program file and introduce it into this file as part of the constructor

        I was going to write the reasons why, but I used ChatGPT because I was feeling lazy to type it all out


        #region ChatGPT response

        1. Dependency Injection Principle:
        Flexibility and Reusability: By injecting the List<Contact> through the constructor, you allow the ContactManager class to work with any list provided to it. This makes your class more flexible and reusable since it is not tied to a specific instance of the List<Contact>. This aligns with the Dependency Injection principle, which promotes loose coupling between components.
        Testing: Constructor injection makes unit testing easier. You can pass a mock or a stub List<Contact> when testing the ContactManager class, isolating the class from the rest of the system.
        
        2. Single Responsibility Principle (SRP):
        Separation of Concerns: The ContactManager class should focus on managing contacts rather than being responsible for the creation and management of the list itself. By injecting the List<Contact>, you're keeping the concerns of list management separate from the ContactManager's functionality, adhering to the SRP.
        
        3. Encapsulation and Control:
        Encapsulation: Injecting the list via a constructor keeps the ContactManager in control of the List<Contact> instance it operates on without being responsible for its creation. This can help ensure that the ContactManager is always working with a properly initialized list.
        Control over Initialization: The class that creates and initializes the ContactManager can control the state of the list when it's passed in, ensuring it meets any necessary preconditions (e.g., it might be pre-populated or configured in a specific way).
        
        4. Immutability (optional):
        If you inject the list via a constructor, you can make the contacts field readonly, ensuring that the ContactManager cannot replace the list reference after construction. This helps to maintain immutability of the contacts reference, providing better stability and predictability.
        #endregion

        Basically, you want something like:

        private readonly List<Contact> _contacts;
        
        public ContactManager(List<Contact> contacts)
        {
            _contacts = contacts;
        }

        */

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
            return contacts.First(c => c.Id == id);
        }

        public void UpdateContact(Contact contact)
        {
            var exisitingContact = GetContactById(contact.Id);

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
