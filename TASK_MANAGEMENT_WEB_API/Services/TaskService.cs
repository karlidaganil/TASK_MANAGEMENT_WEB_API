using TASK_MANAGEMENT_WEB_API.Common;
using TASK_MANAGEMENT_WEB_API.Dto;
using TASK_MANAGEMENT_WEB_API.Repositories;

namespace TASK_MANAGEMENT_WEB_API.Services;

public class TaskService(ITaskRepository taskRepository) : ITaskService
{
    public async Task<PagedResponseModel<List<GetTaskDto>>> GetAllTasks(GetTasksFilterDto filter)
    {
        return await taskRepository.GetAllTasks(filter);
    }

    public async Task<ResponseModel<bool>> CreateTaskAsync(CreateTaskDto dto)
    {
        return await taskRepository.CreateTaskAsync(dto);
    }

    public Task<ResponseModel<GetTaskDto?>> GetTaskByIdAsync(int id)
    {
        return taskRepository.GetTaskByIdAsync(id);
    }

    public Task<ResponseModel<bool>> DeleteTaskAsync(int id)
    {
        return taskRepository.DeleteTaskAsync(id);
    }

    public Task<ResponseModel<GetTaskDto>> UpdateTaskAsync(UpdateTaskDto dto)
    {
        return taskRepository.UpdateTaskAsync(dto);
    }
}