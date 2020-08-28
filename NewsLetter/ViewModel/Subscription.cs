using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsLetter.ViewModel
{
    public class Subscription
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string VerificationCode { get; set; }

        public bool IsVerified { get; set; }


        public Subscription(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public Subscription()
        {

        }
    }
}
