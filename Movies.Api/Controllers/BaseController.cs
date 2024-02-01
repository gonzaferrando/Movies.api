using Microsoft.AspNetCore.Mvc;

namespace Movies.Api.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        // IN HERE WE CAN WRITE SHARED CODE USEFUL FOR ALL CONTROLLERS.
    }
}
