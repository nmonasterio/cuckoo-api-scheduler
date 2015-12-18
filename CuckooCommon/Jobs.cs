using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CuckooCommon
{
    public class Jobs
    {
        public ObjectId JobId { get; set; }
        public DateTime StartTime { get; set; }
        public string Name { get; set;  }
        public string Description { get; set; }

        private static void createJobsDatabase()
        {
            const string connectionString = "mongodb://localhost";
            var mongo = new MongoClient(connectionString);
            

            var blog = mongo.GetDatabase("Cuckoo");

        }

        public static IMongoCollection<Jobs> GetAllJobs()
        {
            //createJobsDatabase();

            const string connectionString = "mongodb://localhost";

            var mongo = new MongoClient(connectionString);
            //var dbs = mongo.ListDatabases();

            //var x = dbs.ToList();

            var db = mongo.GetDatabase("Cuckoo");

            var jobs = db.GetCollection<Jobs>("jobs");

            jobs.InsertOne(new Jobs
                {
                    StartTime = DateTime.Now,
                    Name = "Test",
                    Description = "Amazingness"
                });

            return jobs;
        }

    }
}
