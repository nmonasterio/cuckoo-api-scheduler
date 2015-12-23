using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace CuckooCommon
{
    public class Jobs
    {
        private IMongoDatabase _cuckooDB { get; set; }

        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }
        public DateTime StartTime { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string Endpoint { get; set; }
        public HttpMethods Method { get; set; }

        [BsonIgnore]
        public string MethodDescription { get { return this.Method.ToString(); } }

        public List<APIRequestHeaders> APIRequestHeaders { get; set; }
        public string Payload { get; set; }
        public int Interval { get; set; }
        public Intervals IntervalType { get; set; }

        [BsonIgnore]
        public string IntervalTypeDescription { get { return this.IntervalType.ToString(); } }

        public DayOfWeek? DayOfWeek { get; set; } 

        public Jobs()
        {
            this._cuckooDB = getCuckooDB();
        }

        private static void createJobsDatabase()
        {
            const string connectionString = "mongodb://localhost";
            var mongo = new MongoClient(connectionString);

            mongo.DropDatabase("Cuckoo");
            var blog = mongo.GetDatabase("Cuckoo");

        }

        private static IMongoDatabase getCuckooDB()
        {
            const string connectionString = "mongodb://localhost";

            var mongo = new MongoClient(connectionString);
            return mongo.GetDatabase("Cuckoo");
        }

        public async Task<List<Jobs>> GetAllJobs()
        {
            //this._cuckooDB.DropCollection("jobs");

            var collection = this._cuckooDB.GetCollection<Jobs>("jobs");

            var filter = new BsonDocument();

            //collection.InsertOne(new Jobs
            //{
            //    StartTime = DateTime.Now,
            //    Name = "Another",
            //    Description = "Amazingness",
            //    IsActive = true
            //});

            return await collection.Find(filter).ToListAsync();

        }

        public async Task<Jobs> GetJobById(string id)
        {
            var collection = this._cuckooDB.GetCollection<Jobs>("jobs");

            var f = Builders<Jobs>.Filter.Eq("_id", ObjectId.Parse(id));
            return await collection.Find(f).SingleAsync();
        }

        public async Task<Jobs> AddNewJob(Jobs job)
        {
            var collection = this._cuckooDB.GetCollection<Jobs>("jobs");
            await collection.InsertOneAsync(job);

            return job;
        }


        public async Task<Jobs> UpdateJob(string id, Jobs job)
        {
            var collection = this._cuckooDB.GetCollection<Jobs>("jobs");

            var f = Builders<Jobs>.Filter.Eq("_id", ObjectId.Parse(id));
            var result = await collection.Find(f).SingleAsync();

            if (result == null)
            {
                throw new NullReferenceException(String.Format("There is no job with an ID of {0}.", id));
            }

            await collection.ReplaceOneAsync(x => x.Id == ObjectId.Parse(id), job);
            return job;
        }

        public async Task DeleteJob(string id)
        {
            var collection = this._cuckooDB.GetCollection<Jobs>("jobs");

            var f = Builders<Jobs>.Filter.Eq("_id", ObjectId.Parse(id));
            var result = await collection.Find(f).SingleAsync();

            if (result == null)
            {
                throw new NullReferenceException(String.Format("There is no job with an ID of {0}.", id));
            }

            await collection.DeleteOneAsync(x => x.Id == ObjectId.Parse(id));
        }
    }
}
