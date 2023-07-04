using Microsoft.AspNetCore.Mvc;
using TaskManager.API.Data.Repositories;
using TaskManager.API.Models;
using TaskManager.API.Models.InputModels;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private ITaskRepository _taskrepository;

        public TaskController(ITaskRepository taskrepository)
        {
            _taskrepository = taskrepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var tasks = _taskrepository.GetAllTask();

            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var task = _taskrepository.GetOneTask(id);

            if (task == null)
                return NotFound();

            return Ok(task);
        }

        [HttpPost]
        public IActionResult Post([FromBody] TaskInputModel newTask)
        {
            var task = new Task(newTask.Name, newTask.Description);

            _taskrepository.Add(task);

            return Created("", task);
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] TaskInputModel updateTask)
        {
            var task = _taskrepository.GetOneTask(id);

            if (task == null)
                return NotFound();

            task.UpdateTask(updateTask.Name, updateTask.Description, updateTask.Finished);

            _taskrepository.Update(id, task);

            return Ok(task);

        }

        // DELETE api/<TaskController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var task = _taskrepository.GetOneTask(id);

            if (task == null)
                return NotFound();

            _taskrepository.Delete(id);

            return NoContent();
        }
    }
}
