using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList
{
    public interface IContact
    {
        void AddContact(Contact contact);
        List<Contact> GetContacts();
        Contact GetContactById(int id);
        void UpdateContact(Contact contact);
        void DeleteContact(int id);

    }
}
