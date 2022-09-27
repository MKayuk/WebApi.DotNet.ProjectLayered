using Microsoft.Extensions.Configuration;
using Base.Infrastructure.Data.Repository.SeedWork.Interface;
using System;

namespace Base.Infrastructure.Data.Repository.SeedWork
{
    public class MongoConnection : IMongoConnection
    {
        private readonly IConfiguration _configuration;

        public MongoConnection(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString()
        {
            if (_configuration == null)
                throw new ArgumentNullException(nameof(_configuration));

            return _configuration["ConnectionStrings:MongoDbConnection"];
        }
    }
}
