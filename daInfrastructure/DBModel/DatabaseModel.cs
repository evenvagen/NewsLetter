using System;
using System.Collections.Generic;
using System.Text;

namespace daInfrastructure
{
    public class DatabaseModel
    {
        public string Email { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsVerified { get; set; }

        public string VerificationCode { get; set; }


        public DatabaseModel(string email, Guid id, string name, bool isVerified, string verificationCode)
        {
            Email = email;
            Id = id;
            Name = name;
            IsVerified = isVerified;
            VerificationCode = verificationCode;
        }

        public DatabaseModel()
        {
            
        }
    }
}
