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
    public class SubscriptionRepository : ISubsciptionRepository
    {

        private readonly string _connectionString;

        public SubscriptionRepository(ConnectionString connectionString)
        {
            _connectionString = connectionString.Value;
        }

        public async Task<bool> Create(Subscription subscription)
        {
            await using var conn = new SqlConnection(_connectionString);

            const string insert = @"INSERT INTO NewsLetter (Email, Id) VALUES (@Email, @Id)";

            var newsLetter = MapToDb(subscription);

            var result = await conn.ExecuteAsync(insert, subscription);

           return result == 1;


        }

        private static DatabaseModel MapToDb(Subscription subscription)
        {
            return new DatabaseModel(subscription.Email, subscription.VerificationCode);
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
