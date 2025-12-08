using Microsoft.AspNetCore.Mvc;
using TASK_MANAGEMENT_WEB_API.Common;
using TASK_MANAGEMENT_WEB_API.Data;
using TASK_MANAGEMENT_WEB_API.Dto;
using TASK_MANAGEMENT_WEB_API.Services;

namespace TASK_MANAGEMENT_WEB_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController(ITaskService taskService, ApplicationDbContext context) : ControllerBase
{
    [HttpGet("all")]
    public async Task<ActionResult<PagedResponseModel<List<GetTaskDto>>>> GetAll([FromQuery] GetTasksFilterDto filter)
    {
        var response = await taskService.GetAllTasks(filter);
        return response.Success ? Ok(response) : StatusCode(500, response);
    }

    [HttpPost("create")]
    public async Task<ActionResult<ResponseModel<bool>>> Create([FromBody] CreateTaskDto dto)
    {
        var response = await taskService.CreateTaskAsync(dto);
        return response.Success ? Ok(response) : StatusCode(500, response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ResponseModel<GetTaskDto?>>> GetById(int id)
    {
        var response = await taskService.GetTaskByIdAsync(id);
        return response.Success ? Ok(response) : StatusCode(500, response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ResponseModel<bool>>> DeleteTaskById(int id)
    {
        var response = await taskService.DeleteTaskAsync(id);
        return response.Success ? Ok(response) : StatusCode(500, response);
    }

    [HttpPut("update")]
    public async Task<ActionResult<ResponseModel<GetTaskDto>>> UpdateTask([FromBody] UpdateTaskDto dto)
    {
        var response = await taskService.UpdateTaskAsync(dto);
        return response.Success ? Ok(response) : StatusCode(500, response);
    }
    
    [HttpDelete("all")]
    public async Task<ActionResult<ResponseModel<bool>>> DeleteAllTasks(int id)
    {
        var response = await taskService.DeleteAllTasksAsync();
        return response.Success ? Ok(response) : StatusCode(500, response);
    }
}