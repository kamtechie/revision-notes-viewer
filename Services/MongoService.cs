using RevisionNotes.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace RevisionNotes.Services
{
    public class MongoService
    {

        private readonly IMongoCollection<Topic> _topicsCollection;
        private readonly IMongoCollection<Note> _notesCollection;

        public MongoService(IOptions<DatabaseSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);

            _topicsCollection = database.GetCollection<Topic>("topics");
            _notesCollection = database.GetCollection<Note>("notes");
        }

        public async Task<List<Topic>> GetAllTopicsAsync()
        {
            return await _topicsCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Topic> GetTopicByIdAsync(string id)
        {
            return await _topicsCollection.Find(topic => topic.id == id).FirstOrDefaultAsync();
        }

        public async Task<Note> GetNoteByTopicIdAsync(string id)
        {
            return await _notesCollection.Find(note => note.topic == id).FirstOrDefaultAsync();
        }
    }
}