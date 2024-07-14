using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace DemoAZFunctionApp
{
    public class FuncScheduledTrigger
    {
        private readonly ILogger _logger;

        public FuncScheduledTrigger(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<FuncScheduledTrigger>();
        }

        [Function("FuncScheduledTrigger")]
        public void Run([TimerTrigger("0 */5 * * * *")] TimerInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            
            if (myTimer.ScheduleStatus is not null)
            {
                _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
            }
        }
    }
}
