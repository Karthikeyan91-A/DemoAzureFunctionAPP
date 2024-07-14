using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace DemoAZFunctionApp
{
    public class FuncHttpTrigger
    {
        private readonly ILogger<FuncHttpTrigger> _logger;

        public FuncHttpTrigger(ILogger<FuncHttpTrigger> logger)
        {
            _logger = logger;
        }

        [Function("FuncHttpTrigger")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function Entered");
            return new OkObjectResult("Hello, This is the Demo for Azure Function App");
        }
    }
}
