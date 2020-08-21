using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Core;

namespace DomainServices.Core
{
    public interface IEmailService
    {
        Task<bool> Send(Email email);
    }
}
