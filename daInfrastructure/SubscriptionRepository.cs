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
            const string read = @"SELECT Name, Email, IsVerified FROM NewsLetter WHERE Name = @Name";
            var result = await conn.QueryAsync<ToDataBase>(read, new {Name = name});
            var gameModel = result.SingleOrDefault();

            return new Subscription
            {
                Email = gameModel.Email,
                Name = gameModel.Name,
                IsVerified = gameModel.IsVerified,
            };
        }

        public async Task<Subscription> ReadByEmail(string email)
        {
            await using var conn = new SqlConnection(_connectionString);
            const string update = @"SELECT * FROM NewsLetter WHERE Email = @Email";
            var models = await conn.QueryAsync<ToDataBase>(update, new { Email = email });
            var gameModel = models.SingleOrDefault();

            //verCode
            return new Subscription {VerificationCode = gameModel.VerificationCode};
        }

        private static ToDataBase MapToDb(Subscription subscription)
        {
            return new ToDataBase(subscription.Email, subscription.Id, subscription.Name, subscription.IsVerified, subscription.VerificationCode);
        }


        public async Task<bool> Update(Subscription subscription)
        {
            await using var conn = new SqlConnection(_connectionString);

            const string insert = @"UPDATE NewsLetter 
            SET IsVerified = '1' Where VerificationCode = @VerificationCode";

            var newsLetter = MapToDb(subscription);

            var result = await conn.ExecuteAsync(insert, newsLetter);

            return result == 1;
        }
    }
}
