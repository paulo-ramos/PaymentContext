using PaymentContext.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Tests.Commands
{
    [TestClass]
    public class CreateBoletoSubscriptionCommandTests
    {
        [TestMethod]
        public void ShowdReturn_Error_When_Name_IsInvalid()
        {
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "";

            Assert.IsFalse(command.Validate());
        }

        [TestMethod]
        public void ShowdReturn_Success_When_Name_IsValid()
        {
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "Paulo";
            command.LastName = "Ramos";

            Assert.IsTrue(command.Validate());
        }
    }
}
