using MongoDB.Driver;
using Base.Infrastructure.Data.Repository.SeedWork.Interface;

namespace Base.Infrastructure.Data.Repository.SeedWork
{
    public class MongoContext<TConn> : IMongoContext where TConn : IMongoConnection
    {
        private IMongoClient _client { get; init; }
        private IMongoDatabase _database { get; init; }

        public MongoContext(TConn connection)
        {
            var url = new MongoUrl(connection.GetConnectionString());
            this._client = new MongoClient(url.Url);
            this._database = this._client.GetDatabase(url.DatabaseName);
        }

        IMongoDatabase IMongoContext.Database
        {
            get
            {
                return _database;
            }
        }

        #region Collections

        // TODO: Set collections

        // TODO: Set collection name
        /// <summary>
        /// Bases' Collection
        /// </summary>
        public IMongoCollection<Model.Base> Bases => _database.GetCollection<Model.Base>("bases");

        #endregion
    }
}
