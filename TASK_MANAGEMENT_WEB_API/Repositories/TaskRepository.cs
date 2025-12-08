using Microsoft.EntityFrameworkCore;
using TASK_MANAGEMENT_WEB_API.Common;
using TASK_MANAGEMENT_WEB_API.Data;
using TASK_MANAGEMENT_WEB_API.Dto;
using TASK_MANAGEMENT_WEB_API.Entity;

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

    public async Task<ResponseModel<bool>> CreateTaskAsync(CreateTaskDto dto)
    {
        var responseModel = new ResponseModel<bool>();

        var taskToCreate = new Job
        {
            Title = dto.title,
            Description = dto.description,
            Status = dto.status,
            DueDate = dto.dueDate
        };

        await context.Tasks.AddAsync(taskToCreate);
        await context.SaveChangesAsync();

        responseModel.Payload = true;
        return responseModel;
    }

    public async Task<ResponseModel<GetTaskDto?>> GetTaskByIdAsync(int id)
    {
        var responseModel = new ResponseModel<GetTaskDto?>();

        var task = await context.Tasks.FindAsync(id);
        if (task == null)
        {
            responseModel.Success = false;
            responseModel.Message = "Task not found";
            return responseModel;
        }

        responseModel.Payload = new GetTaskDto(
            task.Id,
            task.Title,
            task.Description,
            task.Status,
            task.DueDate);

        return responseModel;
    }
}