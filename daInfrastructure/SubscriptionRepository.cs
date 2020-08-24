using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Dapper;
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

        public async Task<bool> Create(Subscription subscription)
        {
            await using var conn = new SqlConnection(_connectionString);

            const string insert = @"INSERT INTO NewsLetter (Email, ConfirmationGuid) VALUES (@Email, @ConfirmationGuid)";

            var newsLetter = MapToDb(subscription);

           var result = await conn.ExecuteAsync(insert, newsLetter);

           return result == 1;


        }

        private static DatabaseModel MapToDb(Subscription subscription)
        {
            return new DatabaseModel(subscription.Email);
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
