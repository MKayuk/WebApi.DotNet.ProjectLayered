using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Base.Infrastructure.Data.Model
{
    public record Base
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        [BsonElement("id")]
        public Guid Id { get; set; }

        [BsonElement("cpf")]
        public string Cpf { get; set; }
    }
}
