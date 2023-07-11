using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RevisionNotes.Models
{
    public class Topic
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string name { get; set; }

        public string subject { get; set; }

        public string board { get; set; }

        public string level { get; set; }
    }
}