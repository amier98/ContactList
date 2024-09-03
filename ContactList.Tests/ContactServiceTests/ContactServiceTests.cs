using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Diagnostics.Contracts;
using System.IO;

namespace ContactList.Tests
{
    [TestClass]
    public class ContactServiceTests : ContactServiceTestBase
    {
        [TestMethod]
        public void GivenContactIsAdded_ThenAddContactIsCalled()
        {
            // arrange
            var service = GetService();
            var input = new StringReader("amier\n12344\n");
            Console.SetIn(input);

            // act
            service.AddContact();

            // assert
            _contact.Verify(c => c.AddContact(
                   It.IsAny<Contact>()), Times.Once);
        }
    }
}
