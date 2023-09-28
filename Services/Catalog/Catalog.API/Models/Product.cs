using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Catalog.API.Models
{
    public class Product
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.Decimal128)]
        public decimal Price { get; set; }
        public string Picture { get; set; }

        public string UserId { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        public DateTime CreatedTime { get; set; }
        public Feature Feature { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string CategoryId { get; set; }
        
        [BsonIgnore]
        public Category Category { get; set; }

    }
}
