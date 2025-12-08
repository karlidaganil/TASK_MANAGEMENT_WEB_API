using TASK_MANAGEMENT_WEB_API.Enums;

namespace TASK_MANAGEMENT_WEB_API.Dto;

public record UpdateTaskDto(
    int Id,
    string Title,
    string Description,
    Status Status,
    DateTime DueDate
);