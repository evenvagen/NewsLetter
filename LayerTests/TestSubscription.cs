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


            emailInterfaceMock.Verify(es => es.Send(It.Is<Email>(n => n.To == "evenv@mail.net")), Times.Exactly(1));

            subscriptionInterfaceMock.Verify(ns => ns.Create(It.Is<Subscription>(n => n.Name == "Even")), Times.Once);

            //AllCalls
            emailInterfaceMock.VerifyNoOtherCalls();
            subscriptionInterfaceMock.VerifyNoOtherCalls();
        }


        [Test]
        public async Task checkEmailServiceFail()
        {
            var emailInterfaceMock = new Mock<IEmailService>();
            var subscriptionInterfaceMock = new Mock<ISubsciptionRepository>();

            subscriptionInterfaceMock.Setup(sub => sub.Create(It.IsAny<Subscription>())).ReturnsAsync(false);


            //Arrange 
            var subscriptionService = new SubscriptionService(emailInterfaceMock.Object, subscriptionInterfaceMock.Object);
            var subscription = new Subscription("Even", "evenvagen@mail.net");
            var go = await subscriptionService.Subscribe(subscription);


            Assert.IsFalse(go);

            subscriptionInterfaceMock.Verify(sub => sub.Create(It.Is<Subscription>(m => m.Email == "evenvagen@mail.net")));

            emailInterfaceMock.VerifyNoOtherCalls();
            subscriptionInterfaceMock.VerifyNoOtherCalls();
        }
    }
}