using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Core;
using DomainServices.Core;

namespace daInfrastructure
{
    class SubscriptionRepository : ISubsciptionRepository
    {

        private readonly string _connectionString;

        public SubscriptionRepository(ConnectionString connectionString)
        {
            _connectionString = connectionString.Value;
        }

        public Task<bool> Create(Subscription subscription)
        {
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
