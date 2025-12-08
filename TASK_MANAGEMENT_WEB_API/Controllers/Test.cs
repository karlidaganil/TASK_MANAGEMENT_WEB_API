using Microsoft.AspNetCore.Mvc;

namespace TASK_MANAGEMENT_WEB_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Test : ControllerBase
{
    public String Testasd()
    {
        return "Hello World";
    }
}