using System;

namespace DomainModel.Core
{
    public class Subscription : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string VerificationCode { get; set; }
        public bool IsVerified { get; set; }

        public Subscription()
        {

        }

        public Subscription(string name, string email, string verificationCode = null)
        {
            Name = name;
            Email = email;
            VerificationCode = verificationCode ?? Guid.NewGuid().ToString();
        }
    }
}
