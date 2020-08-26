using System;
using System.Collections.Generic;
using System.Text;
using DomainModel.Core;
using NUnit.Framework;

namespace LayerTests
{
    class TestSubscriptionEmail
    {
        [Test]
        public void SubLink()
        {
            var sub = new ConfirmSubscriptionEmail("even@gmail.com", "mike@nasa.com",
                "9c525c5d-99bc-4ff5-8a3b-2ca0958de88a");
        }
    }
}
