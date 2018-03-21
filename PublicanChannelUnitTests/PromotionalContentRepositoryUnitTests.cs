using System;
using EiGroupPlc.Application.PublicanChannel.Repositories;
using NUnit.Framework;

namespace PublicanChannelUnitTests
{
    [TestFixture]
    public class PromotionalContentRepositoryUnitTests
    {
        [SetUp]
        public void SetUp()
        {
            
        }

        [Test]
        public void PromotionalContentRepositoryReturnsDefaultValuesFromDatabase()
        {
            var target = new PromotionalContentRepository();
            var actualResult = target.GetPromotionalContentByPageId("/Default.aspx");

            Assert.AreEqual(5, actualResult.Count);
        }
    }
}
