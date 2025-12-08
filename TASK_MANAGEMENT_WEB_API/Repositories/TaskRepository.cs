using Microsoft.EntityFrameworkCore;
using TASK_MANAGEMENT_WEB_API.Common;
using TASK_MANAGEMENT_WEB_API.Data;
using TASK_MANAGEMENT_WEB_API.Dto;
using TASK_MANAGEMENT_WEB_API.Entity;

namespace TASK_MANAGEMENT_WEB_API.Repositories;

public class TaskRepository(ApplicationDbContext context) : ITaskRepository
{
    public async Task<PagedResponseModel<List<GetTaskDto>>> GetAllTasks(GetTasksFilterDto filter)
    {
        var responseModel = new PagedResponseModel<List<GetTaskDto>>();
        try
        {
            var query = context.Tasks.AsQueryable();

            if (filter.Status.HasValue)
            {
                query = query.Where(t => t.Status == filter.Status.Value);
            }

            if (filter.DueDateFrom.HasValue)
            {
                query = query.Where(t => t.DueDate >= filter.DueDateFrom.Value);
            }

            if (filter.DueDateTo.HasValue)
            {
                query = query.Where(t => t.DueDate <= filter.DueDateTo.Value);
            }

            var totalCount = await query.CountAsync();

            var pageNumber = filter.PageNumber > 0 ? filter.PageNumber : 1;
            var pageSize = filter.PageSize > 0 ? filter.PageSize : 10;

            var tasks = await query
                .OrderBy(t => t.DueDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var payload = tasks.Select(task => new GetTaskDto(
                task.Id,
                task.Title,
                task.Description,
                task.Status,
                task.DueDate)).ToList();

            responseModel.Payload = payload;
            responseModel.PageNumber = pageNumber;
            responseModel.PageSize = pageSize;
            responseModel.TotalCount = totalCount;

            return responseModel;
        }
        catch (Exception ex)
        {
            responseModel.Success = false;
            responseModel.Message = ex.Message;
            return responseModel;
        }
    }

    public async Task<ResponseModel<bool>> CreateTaskAsync(CreateTaskDto dto)
    {
        var responseModel = new ResponseModel<bool>();
        try
        {
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
        catch (Exception ex)
        {
            responseModel.Success = false;
            responseModel.Message = ex.Message;
            return responseModel;
        }
    }

    public async Task<ResponseModel<GetTaskDto?>> GetTaskByIdAsync(int id)
    {
        var responseModel = new ResponseModel<GetTaskDto?>();
        try
        {
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
        catch (Exception ex)
        {
            responseModel.Success = false;
            responseModel.Message = ex.Message;
            return responseModel;
        }
    }

    public async Task<ResponseModel<bool>> DeleteTaskAsync(int id)
    {
        var responseModel = new ResponseModel<bool>();
        try
        {
            var taskToDelete = await context.Tasks.FindAsync(id);
            if (taskToDelete == null)
            {
                responseModel.Success = false;
                responseModel.Message = "Task not found";
                return responseModel;
            }

            context.Tasks.Remove(taskToDelete);
            await context.SaveChangesAsync();

            return responseModel;
        }
        catch (Exception ex)
        {
            responseModel.Success = false;
            responseModel.Message = ex.Message;
            return responseModel;
        }
    }

    public async Task<ResponseModel<GetTaskDto>> UpdateTaskAsync(UpdateTaskDto dto)
    {
        var responseModel = new ResponseModel<GetTaskDto>();
        try
        {
            var taskToUpdate = await context.Tasks.FindAsync(dto.Id);
            if (taskToUpdate == null)
            {
                responseModel.Success = false;
                responseModel.Message = "Task not found";
                return responseModel;
            }

            taskToUpdate.Title = dto.Title;
            taskToUpdate.Description = dto.Description;
            taskToUpdate.Status = dto.Status;
            taskToUpdate.DueDate = dto.DueDate;

            await context.SaveChangesAsync();

            var taskToReturn = new GetTaskDto(taskToUpdate.Id, taskToUpdate.Title, taskToUpdate.Description,
                taskToUpdate.Status, taskToUpdate.DueDate);

            responseModel.Payload = taskToReturn;

            return responseModel;
        }
        catch (Exception ex)
        {
            responseModel.Success = false;
            responseModel.Message = ex.Message;
            return responseModel;
        }
    }

    public async Task<ResponseModel<bool>> DeleteAllTasksAsync()
    {
        var responseModel = new ResponseModel<bool>();
        try
        {
            context.Tasks.RemoveRange(context.Tasks);
            await context.SaveChangesAsync();
            responseModel.Message = "All Tasks deleted";
            return responseModel;
        }
        catch (Exception ex)
        {
            responseModel.Success = false;
            responseModel.Message = ex.Message;
            return responseModel;
        }
    }
}