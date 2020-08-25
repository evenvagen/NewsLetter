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
        public Guid Id { get; set; }
        public bool IsVerified { get; set; }

        //public Subscription(string name, string email, Guid id, bool isVerified)
        //{
        //    Name = name;
        //    Email = email;
        //    Id = id;
        //    IsVerified = isVerified;
        //}

        //public Subscription()
        //{

        //}
    }
}
