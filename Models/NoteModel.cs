using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RevisionNotes.Models
{
    public class Note
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string topic { get; set; }

        public string content { get; set; }
    }
}