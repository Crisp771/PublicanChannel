using System;
using System.Collections.Generic;
using EiGroupPlc.Application.PublicanChannel.Mappers;
using EiGroupPlc.Application.PublicanChannel.PropertyBags;
using EiGroupPlc.Services.Contracts.Dtos.PromotionalContent;
using NUnit.Framework;

namespace PublicanChannelUnitTests
{
    [TestFixture]
    public class PromotionalContentMapperUnitTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void PromotionalContentMapperMapsTypesCorrectly()
        {
            var target = new PromotionalContentMapper();
            var imageUrl = Guid.NewGuid().ToString();
            var expectedResult = new List<PromotionalContentDto>() { new PromotionalContentDto() { ImageUrl = imageUrl } };
            var promotionalContentList = new List<PromotionalContent>() {
                new PromotionalContent()
                {
                    Guid = Guid.NewGuid(),
                    ImageUrl = imageUrl,
                    PageId = Guid.NewGuid().ToString()
                }
            };

            var actualResult = target.Map(promotionalContentList);

            Assert.AreEqual(1, actualResult.Count);
            Assert.AreEqual(imageUrl, actualResult[0].ImageUrl);
        }
    }
}
