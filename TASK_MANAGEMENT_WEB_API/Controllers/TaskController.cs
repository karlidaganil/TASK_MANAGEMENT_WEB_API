using Microsoft.AspNetCore.Mvc;
using TASK_MANAGEMENT_WEB_API.Common;
using TASK_MANAGEMENT_WEB_API.Data;
using TASK_MANAGEMENT_WEB_API.Dto;
using TASK_MANAGEMENT_WEB_API.Entity;
using TASK_MANAGEMENT_WEB_API.Repositories;
using TASK_MANAGEMENT_WEB_API.Services;

namespace TASK_MANAGEMENT_WEB_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController(ITaskService taskService) : ControllerBase
{
    [HttpGet("all")]
    public async Task<ResponseModel<List<GetTaskDto>>> GetAll()
    {
        return await taskService.GetAllTasks();
    }

    [HttpPost("create")]
    public async Task<ResponseModel<bool>> Create([FromBody] CreateTaskDto dto)
    {
        return await taskService.CreateTaskAsync(dto);
    }

    [HttpGet("{id}")]
    public async Task<ResponseModel<GetTaskDto?>> GetById(int id)
    {
        return await taskService.GetTaskByIdAsync(id);
    }

    [HttpDelete("{id}")]
    public async Task<ResponseModel<bool>> DeleteTaskById(int id)
    {
        return await taskService.DeleteTaskAsync(id);
    }

    [HttpPut("update")]
    public async Task<ResponseModel<GetTaskDto>> UpdateTask([FromBody] UpdateTaskDto dto)
    {
        return await taskService.UpdateTaskAsync(dto);
    }
}