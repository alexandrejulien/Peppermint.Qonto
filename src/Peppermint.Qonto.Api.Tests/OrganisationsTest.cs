using Apis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Peppermint.Qonto.Api.Tests
{
    [TestClass]
    public class OrganisationsTest
    {
        [TestMethod]
        public void ListOrganisations()
        {
            AuthInfosMock.Configure();

            var client = new OrganizationsApi();
            var results = client.GETOrganizationsId("Organisation ID");

            Assert.IsNotNull(results);
        }
    }
}
