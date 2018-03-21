using EiGroupPlc.Application.PublicanChannel.Interfaces.Mappers;
using EiGroupPlc.Application.PublicanChannel.Interfaces.Repositories;
using EiGroupPlc.Application.PublicanChannel.PropertyBags;
using EiGroupPlc.Application.PublicanChannel.Services;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace PublicanChannelUnitTests
{
    [TestFixture]
    public class PromotionalContentServiceUnitTests
    {

        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void PromotionalContentServiceCallsDependenciesCorrectly()
        {
            IPromotionalContentRepository promotionalContentRepository = Substitute.For<IPromotionalContentRepository>();
            IPromotionalContentMapper mapper = Substitute.For <IPromotionalContentMapper>();

            var pageIdRequest = Guid.NewGuid().ToString();

            var target = new PromotionalContentService(promotionalContentRepository, mapper);

            target.GetPromotionalContent(pageIdRequest);

            mapper.Received().Map(Arg.Any<IList<PromotionalContent>>());
            promotionalContentRepository.Received().GetPromotionalContentByPageId(pageIdRequest);
        }
    }
}
