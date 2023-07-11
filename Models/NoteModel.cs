using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RevisionNotes.Models
{
    public class Note
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Topic { get; set; }

        public string Content { get; set; }
    }
}