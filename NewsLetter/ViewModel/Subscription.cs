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

        public string Id { get; set; }


        public Subscription(string name, string email, string id)
        {
            Name = name;
            Email = email;
            Id = id;
        }

        public Subscription()
        {

        }
    }
}
