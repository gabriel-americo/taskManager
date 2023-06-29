using MongoDB.Driver;
using System.Collections.Generic;
using TaskManager.API.Data.Configurations;
using TaskManager.API.Models;

namespace TaskManager.API.Data.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IMongoCollection<Task> _task;

        public TaskRepository(IDatabaseConfig databaseConfig)
        {
            var client = new MongoClient(databaseConfig.ConnectionString);
            var database = client.GetDatabase(databaseConfig.DatabaseName);

            _task = database.GetCollection<Task>("task");
        }

        public void Add(Task task)
        {
            _task.InsertOne(task);
        }

        public void Update(string id, Task taskupdate)
        {
            _task.ReplaceOne(task => task.Id == id, taskupdate);
        }

        public IEnumerable<Task> GetAllTask()
        {
            return _task.Find(task => true).ToList();
        }

        public Task GetOneTask(string id)
        {
            return _task.Find(task => task.Id == id).FirstOrDefault();
        }

        public void Delete(int id)
        {

        }
    }
}
