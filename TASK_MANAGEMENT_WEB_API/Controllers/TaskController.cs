using Microsoft.AspNetCore.Mvc;
using TASK_MANAGEMENT_WEB_API.Common;
using TASK_MANAGEMENT_WEB_API.Data;
using TASK_MANAGEMENT_WEB_API.Dto;
using TASK_MANAGEMENT_WEB_API.Entity;
using TASK_MANAGEMENT_WEB_API.Repositories;

namespace TASK_MANAGEMENT_WEB_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController(ITaskRepository taskRepository) : ControllerBase
{
    [HttpGet("all")]
    public async Task<ResponseModel<List<GetTaskDto>>> GetAll()
    {
        return await taskRepository.GetAllTasks();
    }

    [HttpPost("create")]
    public async Task<ResponseModel<bool>> Create([FromBody] CreateTaskDto dto)
    {
        return await taskRepository.CreateTaskAsync(dto);
    }
}