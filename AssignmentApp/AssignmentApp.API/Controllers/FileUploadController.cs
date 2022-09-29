using Microsoft.AspNetCore.Mvc;


namespace AssignmentApp.API.Controllers;

[ApiController]
[Route("[controller]")]
public class FileUploadController : ControllerBase
{

    [HttpPost]
    [Route("upload")]
    public IActionResult Upload(IFormFile file)
    {
        return Ok("File uploaded!");
    }
    
}