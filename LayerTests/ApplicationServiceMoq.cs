using System.Threading.Tasks;
using ApplicationServices.Core;
using DomainModel.Core;
using DomainServices.Core;
using Moq;
using NUnit.Framework;

namespace LayerTests
{
    public class Tests
    {
        
        [Test]
        public async Task TestSubscription()
        {
            //40 Setup
            var emailInterfaceMock = new Mock<IEmailService>();
            var subscriptionInterfaceMock = new Mock<ISubsciptionRepository>();


            emailInterfaceMock.Setup(send => send.Send(It.IsAny<Email>())).ReturnsAsync(true);
            subscriptionInterfaceMock.Setup(sub => sub.Create(It.IsAny<Subscription>())).ReturnsAsync(true);


            //30 Arrange
            var service = new SubscriptionService(emailInterfaceMock.Object, subscriptionInterfaceMock.Object);

            var newSubscriber = new Subscription("Even", "evenv@mail.net");
            var subscribeIsSuccess = await service.Subscribe(newSubscriber);

            //Act

            Assert.IsTrue(subscribeIsSuccess);
        }
    }
}