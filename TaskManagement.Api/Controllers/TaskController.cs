using Microsoft.AspNetCore.Mvc;
using TaskManagement.Business.Dtos;
using TaskManagement.Business.Interfaces;

namespace TaskManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("tasks")]
        public async Task<IActionResult> GetAllTasksAsync(string? Status)
        {
            return Ok(await _taskService.GetAllTasksAsync(Status));
        }

        [HttpPost("task")]
        public async Task<IActionResult> AddTaskAsync(TaskDto request)
        {
            return Ok(await _taskService.AddTaskAsync(request));
        }

        [HttpPut("task/{id}")]
        public async Task<IActionResult> UpdateTaskAsync(int id, TaskDto request)
        {
            return Ok(await _taskService.UpdateTaskAsync(id, request));
        }
    }
}
