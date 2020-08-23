using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Core
{
    public class ConfirmSubscriptionEmail : Email
    {
        public ConfirmSubscriptionEmail(string to, string from, string code) : base(to, from, "bekreft abbonement på nyhetsbrev")
        {
            var baseUrl = "http://localhost:44300/subscription";
            var url = $"{baseUrl}?email={to}&code={code}";
            Text = $"<a href=\"{url}\">Klikk her for å bekrefte</a>";
        }


    }
}
