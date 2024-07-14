using System;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.ServiceBus;

using Microsoft.Extensions.Logging;

namespace DemoAZFunctionApp
{
    public class FuncSBTrigger
    {
        
        [Function(nameof(FuncSBTrigger))]
        [ServiceBusOutput("sbouttest", Connection = "ServiceBusConnection")]
        public string ServiceBusFunction(
            [ServiceBusTrigger("sbtest", Connection = "ServiceBusConnection")] string inputMessage,
             FunctionContext context)
        {
            var logger = context.GetLogger<FuncSBTrigger>();
            logger.LogInformation($"C# ServiceBus queue trigger function processed message: {inputMessage}");

            string outputMessage = $"Processed message: {inputMessage}";

            return outputMessage;

        }
    }
}
