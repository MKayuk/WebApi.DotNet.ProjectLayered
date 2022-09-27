using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Base.Infrastructure.Data.Repository.Interface;
using Base.Infrastructure.Data.Repository.SeedWork.Interface;
using System;

namespace Base.Infrastructure.Data.Repository
{
    public class BaseRepository : SeedWork.Repository, IBaseRepository
    {
        private readonly IMongoCollection<Model.Base> _base;

        public BaseRepository(IConfiguration configuration)
            : base(configuration)
        {
            // TODO: Set collection name
            _base = Database.GetCollection<Model.Base>("bases");
        }

        public object Get(Guid id)
        {
            return _base.Find(x => x.Id == id);
        }
    }

    public class BaseRepositoryPoc : IBaseRepository
    {
        private readonly IMongoContext _context;

        public BaseRepositoryPoc(IMongoContext context)
        {
            _context = context;
        }

        public object Get(Guid id)
        {
            return _context.Bases.Find(x => x.Id == id);
        }
    }
}
