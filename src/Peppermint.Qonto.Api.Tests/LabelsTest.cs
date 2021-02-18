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
    public class LabelsTest
    {
        /// <summary>
        /// Test getting all labels.
        /// </summary>
        [TestMethod]
        public void GetAllLabels()
        {
            AuthInfosMock.Configure();

            var client = new LabelsApi();
            var labels = client.GETLabels(null, null);

            Assert.IsNotNull(labels);
        }
    }
}