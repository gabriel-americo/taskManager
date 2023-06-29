using Microsoft.AspNetCore.Mvc;
using TaskManager.API.Data.Repositories;

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
        public void Post([FromBody] string value)
        {

        }

        [HttpPut("{id}")]
        public void Put(string id, [FromBody] string value)
        {

        }

        // DELETE api/<TaskController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {

        }
    }
}
