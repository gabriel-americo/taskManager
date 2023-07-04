using System.Collections.Generic;
using TaskManager.API.Models;

namespace TaskManager.API.Data.Repositories
{
    public interface ITaskRepository
    {
        void Add(Task newTask);
        void Update(string id, Task taskupdate);
        IEnumerable<Task> GetAllTask();
        Task GetOneTask(string id);
        void Delete(string id);
    }
}
