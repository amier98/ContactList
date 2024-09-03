using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace ContactList.Tests
{
    public class ContactServiceTestBase
    {
        protected readonly Mock<IContact> _contact = new Mock<IContact>();
        public ContactService GetService()
        {
            var contact = _contact;

            return new ContactService(
                    contact.Object
                );
        }
    }
}
