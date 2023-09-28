using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Catalog.API.Models
{
    public class Category
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
