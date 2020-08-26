using System;
using System.Collections.Generic;
using System.Text;

namespace daInfrastructure
{
    public class DatabaseModel
    {
        public string Email { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsVerified { get; set; }


        public DatabaseModel(string email, string id, string name, bool isVerified)
        {
            Email = email;
            Id = id;
            Name = name;
            IsVerified = isVerified;
        }
    }
}
