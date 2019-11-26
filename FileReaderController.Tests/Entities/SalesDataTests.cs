using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileReaderController.Domain.Entities;
using FileReaderController.Shared.Enums;
using FileReaderController.Application.Helpers;
using System.Linq;

namespace FileReaderController.Tests.Entities
{
    [TestClass]
    public class SalesDataTests
    {
        

        [TestMethod]
        public void ReturnErrorWhenSalesmanNameIsEmpty()
        {
            SalesData client = new SalesData(lineType: (ELineType)EnumeratorHelper.GetValueFromDescription<ELineType>("003"),
                                                saleId: "03",
                                                salesmanName: "");

            Assert.IsTrue(client.Notifications.Count == 1);
            Assert.IsTrue(client.Notifications.Count(c => c.Property.Equals("SalesData.SalesmanName") && c.Message.Equals("Informacao nao definida")) == 1);
        }

    }
}