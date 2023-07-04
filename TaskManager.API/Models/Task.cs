using System;

namespace TaskManager.API.Models
{
    public class Task
    {
        public Task(string name, string description)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Description = description;
            Finished = false;
            DateRegistration = DateTime.Now;
            DateFinished = null;
        }

        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool Finished { get; private set; }
        public DateTime DateRegistration { get; private set; }
        public DateTime? DateFinished { get; private set; }

        public void UpdateTask(string name, string description, bool? finished)
        {
            Name = name;
            Description = description;
            Finished = finished ?? false;
            DateFinished = Finished ? DateTime.Now : null;
        }
    }
}
