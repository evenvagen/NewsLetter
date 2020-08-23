using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Core;
using DomainServices.Core;

namespace daInfrastructure
{
    class SubscriptionRepository : ISubsciptionRepository
    {
        public Task<bool> Create(Subscription subscription)
        {
            //SQLconn??
            return Task.FromResult(true);
        }

        public Task<Subscription> ReadByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Subscription subscription)
        {
            throw new NotImplementedException();
        }
    }
}
