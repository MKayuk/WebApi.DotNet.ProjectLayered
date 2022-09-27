using MongoDB.Driver;

namespace Base.Infrastructure.Data.Repository.SeedWork.Interface
{
    public interface IMongoContext
    {
        IMongoDatabase Database { get; }

        // TODO: Set collections

        /// <summary>
        /// Bases' Collection
        /// </summary>
        IMongoCollection<Model.Base> Bases { get; }
    }
}
