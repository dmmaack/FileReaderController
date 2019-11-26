using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileReaderController.Domain.Entities;
using FileReaderController.Shared.Enums;
using FileReaderController.Application.Helpers;
using System.Linq;
using FileReaderController.Application.Helpers.ToObject;

namespace FileReaderController.Tests.Entities
{
    [TestClass]
    public class ClientTestes
    {

        [TestMethod]
        public void ReturnErrorWhenNameIsEmpty()
        {
            Client client = new Client(lineType: (ELineType)EnumeratorHelper.GetValueFromDescription<ELineType>("002"),
                                        cNPJ: "94631205000119",
                                        name: "",
                                        businessArea: "administrativo");

            Assert.IsTrue(client.Notifications.Count == 1);
            Assert.IsTrue(client.Notifications.Count(c => c.Property.Equals("Client.Name")) == 1);
        }

        [TestMethod]
        public void ReturnErrorWhenCNPJIsEmpty()
        {
            Client client = new Client(lineType: (ELineType)EnumeratorHelper.GetValueFromDescription<ELineType>("002"),
                                        cNPJ: "",
                                        name: "Jose Alencar",
                                        businessArea: "administrativo");

            Assert.IsTrue(client.Notifications.Count == 2);
            Assert.IsTrue(client.Notifications.Count(c => c.Property.Equals("Client.CNPJ") && c.Message.Equals("Informacao nao definida")) == 1);
            Assert.IsTrue(client.Notifications.Count(c => c.Property.Equals("Client.CNPJ") && c.Message.Equals("Documento invalido")) == 1);
        }

        [TestMethod]
        public void ReturnErrorWhenCNPJInvalid()
        {
            Client client = new Client(lineType: (ELineType)EnumeratorHelper.GetValueFromDescription<ELineType>("002"),
                                        cNPJ: "122355678",
                                        name: "Jose Alencar",
                                        businessArea: "administrativo");

            Assert.IsTrue(client.Notifications.Count == 1);
            Assert.IsTrue(client.Notifications.Count(c => c.Property.Equals("Client.CNPJ") && c.Message.Equals("Documento invalido")) > 0);
        }

        [TestMethod]
        public void ReturnErrorWhenBusinessAreaIsEmpty()
        {
            Client client = new Client(lineType: (ELineType)EnumeratorHelper.GetValueFromDescription<ELineType>("002"),
                                        cNPJ: "",
                                        name: "Jose Alencar",
                                        businessArea: "administrativo");

            Assert.IsTrue(client.Notifications.Count == 1);
            Assert.IsTrue(client.Notifications.Count(c => c.Property.Equals("Client.BusinessArea") && c.Message.Equals("Informacao nao definida")) == 1);
        }

        [TestMethod]
        public void ConvertClientTest(){
            IConvertToObject<Client> convertToObject = new ConvertToClient();
            string line = "002ç23456754345443çJose da SilvaçRural";

            Client client = convertToObject.ExecuteConversion(line);

            Assert.IsTrue(client.Valid);
        }
    }
}