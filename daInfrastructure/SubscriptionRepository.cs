using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DomainModel.Core;
using DomainServices.Core;
using DomainModel = daInfrastructure.DBModel.DomainModel;

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

            const string insert = @"INSERT INTO NewsLetter (Name ,Email, Id, IsVerified, VerificationCode) VALUES (@Name, @Email, @Id, @IsVerified, @VerificationCode)";

            var newsLetter = MapToDb(subscription);

            var result = await conn.ExecuteAsync(insert, newsLetter);

           return result == 1;

        }


        public async Task<Subscription> Read(string name)
        {
            await using var conn = new SqlConnection(_connectionString);
            const string insert = @"SELECT Name, Email FROM NewsLetter WHERE Name = @Name";
            var result = await conn.QueryAsync<DatabaseModel>(insert, new {Name = name});
            var gameModel = result.SingleOrDefault();

            return new Subscription(gameModel.Name, gameModel.Email);
        }


        private static DatabaseModel MapToDb(Subscription subscription)
        {
            return new DatabaseModel(subscription.Email, subscription.Id, subscription.Name, subscription.IsVerified, subscription.VerificationCode);
        }

        public async Task<Subscription> ReadByEmail(string email)
        {
            await using var conn = new SqlConnection(_connectionString);
            const string insert = @"SELECT VerificationCode FROM NewsLetter WHERE Email = @Email";
            var result = await conn.QueryAsync<DatabaseModel>(insert, new { Email = email });
            var gameModel = result.SingleOrDefault();

            return new Subscription(gameModel.Name, gameModel.Email, gameModel.VerificationCode);
        }

        public async Task<bool> Update(Subscription subscription)
        {
            await using var conn = new SqlConnection(_connectionString);

            const string insert = @"UPDATE NewsLetter 
            SET IsVerified = '1' Where Name = 'Joe'";

            var newsLetter = MapToDb(subscription);

            var result = await conn.ExecuteAsync(insert, newsLetter);

            return result == 1;
        }
    }
}
