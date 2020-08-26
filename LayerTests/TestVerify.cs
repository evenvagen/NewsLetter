using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApplicationServices.Core;
using DomainModel.Core;
using DomainServices.Core;
using Moq;
using NUnit.Framework;

namespace LayerTests
{
    class TestVerify
    {
        [Test]
        public async Task VerifyTest()
        {
            var Id = "86e73601-f1b7-41da-ac71-59990060cc5c";

            var subscriptionMock = new Mock<ISubsciptionRepository>();

            Subscription newSubscriber = new Subscription("even", "evenvagen@gmail.com", Id);

            Subscription uniqueSubscription = new Subscription(null, null, Id);

            subscriptionMock.Setup(n => n.Update(It.IsAny<Subscription>())).ReturnsAsync(true);
            subscriptionMock.Setup(m => m.ReadByEmail(It.IsAny<string>())).ReturnsAsync(uniqueSubscription);


            var applicationServices = new SubscriptionService(null, subscriptionMock.Object);

            var result = await applicationServices.Verify(newSubscriber);

            Assert.AreEqual(result, true);
        }
    }
}
