namespace TaskManager.API.Models.InputModels
{
    public class TaskInputModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? Finished { get; set; }
    }
}
