using Microsoft.AspNetCore.Mvc;

namespace Server.Api.Controllers;

public class BaseController : Controller
{
    [NonAction]
    protected IActionResult OkResponse()
    {
        return Ok();
    }
}