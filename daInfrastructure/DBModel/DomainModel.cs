using System;
using System.Collections.Generic;
using System.Text;
using DomainModel.Core;

namespace daInfrastructure.DBModel
{
    class DomainModel
    {
        public string Email { get; set; }

        public DomainModel(string email)
        {
            Email = email;
        }

    }
}
