using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Base.Infrastructure.Data.Repository.SeedWork.Interface;
using System;

namespace Base.Infrastructure.Data.Repository.SeedWork
{
    public class Repository : IRepository
    {
        public Repository(IConfiguration configuration)
        {
            if (configuration is null)
                throw new ArgumentException($"Invalid argument configuration {nameof(configuration)}");

            var client = new MongoClient(configuration["ConnectionStrings:MongoDbConnection"]);
            Database = client.GetDatabase(configuration["ConnectionStrings:DatabaseName"]);
        }

        public IMongoDatabase Database { get; }
    }
}
