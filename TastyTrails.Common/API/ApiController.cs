using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace TastyTrails.Common.API
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public abstract class ApiController : ControllerBase
    {
        protected readonly ILogger _logger;

        protected ApiController(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("ApiLogger");
        }
    }
}