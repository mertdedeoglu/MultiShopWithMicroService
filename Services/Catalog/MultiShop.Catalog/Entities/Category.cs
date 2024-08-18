using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class Category
    {
        //MongoDb de string CategoryId'nin Id oldugunu belirlemek icin asagidaki 2 satir eklenir.
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
