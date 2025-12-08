using TASK_MANAGEMENT_WEB_API.Enums;

namespace TASK_MANAGEMENT_WEB_API.Dto;

public record GetTaskDto(
    int id,
    string title,
    string description,
    Status status,
    DateTime dueDate
);