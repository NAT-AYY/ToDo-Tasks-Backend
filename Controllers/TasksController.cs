
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ToDoBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private static List<TaskItem> Tasks = new List<TaskItem>
        {
            new TaskItem { Id = 1, Name = "Task 1", Status = "pending" },
            new TaskItem { Id = 2, Name = "Task 2", Status = "completed" },
            new TaskItem { Id = 3, Name = "Task 3", Status = "pending" }
        };

        [HttpGet]
        public IActionResult GetTasks()
        {
            return Ok(Tasks);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTaskStatus(int id)
        {
            var task = Tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            task.Status = task.Status == "pending" ? "completed" : "pending";
            return Ok(task);
        }
    }

    public class TaskItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
    }
}
