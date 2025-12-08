using TASK_MANAGEMENT_WEB_API.Common;

namespace TASK_MANAGEMENT_WEB_API.Entity;

public class Job : BaseEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public DateTime DueDate { get; set; }
}