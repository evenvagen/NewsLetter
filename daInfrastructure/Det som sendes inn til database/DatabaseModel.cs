using System;
using System.Collections.Generic;
using System.Text;

namespace daInfrastructure
{
    class DatabaseModel
    {
        public string Email { get; set; }
      

        public DatabaseModel(string email)
        {
            //Her kommer det som sendes inn i databasen, Guid, name?
            Email = email;
        }

        public DatabaseModel()
        {
        }
    }
}
