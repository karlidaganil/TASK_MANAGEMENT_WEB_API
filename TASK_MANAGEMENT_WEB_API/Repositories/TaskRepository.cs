using Microsoft.EntityFrameworkCore;
using TASK_MANAGEMENT_WEB_API.Common;
using TASK_MANAGEMENT_WEB_API.Data;
using TASK_MANAGEMENT_WEB_API.Dto;

namespace TASK_MANAGEMENT_WEB_API.Repositories;

public class TaskRepository(ApplicationDbContext context) : ITaskRepository
{
    public async Task<ResponseModel<List<GetTaskDto>>> GetAllTasks()
    {
        var responseModel = new ResponseModel<List<GetTaskDto>>();
        var tasks = await context.Tasks.ToListAsync();

        var payload = tasks.Select(task => new GetTaskDto(
            task.Id,
            task.Title,
            task.Description,
            task.Status,
            task.DueDate)).ToList();

        responseModel.Payload = payload;
        return responseModel;
    }
}