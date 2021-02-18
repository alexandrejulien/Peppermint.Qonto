using Apis;
using Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Peppermint.Qonto.Api.Tests
{
    /// <summary>
    /// All test about transactions.
    /// </summary>
    [TestClass]
    public class TransactionsTest
    {

        [TestMethod]
        public void GetAllTransactionsTest()
        {
            AuthInfosMock.Configure();

            var client = new TransactionsApi();
            var transactions = client.GETTransactions(
                "Organisation ID", 
                "Account",
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null
                );

            Assert.IsNotNull(transactions);
        }
    }
}
