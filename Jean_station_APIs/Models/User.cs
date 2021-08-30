using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models
{
    public class User
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}
