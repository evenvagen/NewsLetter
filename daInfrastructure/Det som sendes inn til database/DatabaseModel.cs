using System;
using System.Collections.Generic;
using System.Text;

namespace daInfrastructure
{
    class DatabaseModel
    {
        public string Email { get; set; }
        public Guid ConfirmationGuid { get; set; }

        public DatabaseModel(string email, Guid confirmationGuid)
        {
            Email = email;
            ConfirmationGuid = confirmationGuid;
        }
    }
}
