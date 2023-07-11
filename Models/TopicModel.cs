using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RevisionNotes.Models
{
    public class Topic
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }

        public string Subject { get; set; }

        public string Board { get; set; }

        public string Level { get; set; }
    }
}