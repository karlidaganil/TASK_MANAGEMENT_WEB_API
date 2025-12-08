using TASK_MANAGEMENT_WEB_API.Common;
using TASK_MANAGEMENT_WEB_API.Dto;

namespace TASK_MANAGEMENT_WEB_API.Repositories;

public interface ITaskRepository
{
    public Task<ResponseModel<List<GetTaskDto>>> GetAllTasks();
    public Task<ResponseModel<bool>> CreateTaskAsync(CreateTaskDto dto);
}