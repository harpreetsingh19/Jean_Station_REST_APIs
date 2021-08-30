using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Models
{
    public class DataContext
    {
        private readonly IMongoDatabase database;
        readonly MongoClient client;

        public DataContext(IConfiguration configuration)
        {
            client = new MongoClient(configuration.GetSection("MongoDB:ConnectionString").Value);
            database = client.GetDatabase(configuration.GetSection("MongoDB:AuthDatabase").Value);
        }

        public IMongoCollection<User> Users => database.GetCollection<User>("Users");
        public IMongoCollection<Activeuser> Activeusers => database.GetCollection<Activeuser>("Activeusers");
    }
}
