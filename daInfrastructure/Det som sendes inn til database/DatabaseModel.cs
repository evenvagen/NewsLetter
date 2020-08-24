using System;
using System.Collections.Generic;
using System.Text;

namespace daInfrastructure
{
    public class DatabaseModel
    {
        public string Email { get; set; }
        public string Id { get; set; }

        public DatabaseModel(string email, string id)
        {
            Email = email;
            Id = id;
        }
    }
}
