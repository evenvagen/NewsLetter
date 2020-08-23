using System;
using System.Threading.Tasks;
using DomainModel.Core;
using DomainServices.Core;

namespace daInfrastructure
{
    public class EmailService : IEmailService
    {
        public Task<bool> Send(Email email)
        {
            return Task.FromResult(true);
        }
    }
}
