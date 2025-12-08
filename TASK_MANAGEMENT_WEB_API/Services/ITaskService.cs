using TASK_MANAGEMENT_WEB_API.Common;
using TASK_MANAGEMENT_WEB_API.Dto;

namespace TASK_MANAGEMENT_WEB_API.Services;

public interface ITaskService
{
    Task<PagedResponseModel<List<GetTaskDto>>> GetAllTasks(GetTasksFilterDto filter);
    Task<ResponseModel<bool>> CreateTaskAsync(CreateTaskDto dto);
    Task<ResponseModel<GetTaskDto?>> GetTaskByIdAsync(int id);
    Task<ResponseModel<bool>> DeleteTaskAsync(int id);
    Task<ResponseModel<GetTaskDto>> UpdateTaskAsync(UpdateTaskDto dto);
    Task<ResponseModel<bool>> DeleteAllTasksAsync();
}