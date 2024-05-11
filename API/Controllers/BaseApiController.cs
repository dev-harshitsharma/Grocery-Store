using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //This class is responsible for giving routes to the controllers
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController: ControllerBase
    {
        
    }
}