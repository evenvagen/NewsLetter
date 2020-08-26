using System;
using System.Collections.Generic;
using System.Text;
using DomainModel.Core;
using NUnit.Framework;

namespace LayerTests
{
    class TestSubscriptionClass
    {
        [Test]
        public void TestVerified()
        {
            var sub = new Subscription("even", "even@gmail.com");

            Assert.AreEqual(sub.IsVerified, false);
        }

        [Test]
        public void BaseEntityTest()
        {
            var sub = new Subscription("Even", "even@gmail.com");
            var result = sub.Id = new Guid("0d8e2b20-5d62-49f0-8b19-c53c93d8e993");

            Assert.AreEqual(sub.Id, result);
        }
    }
}
