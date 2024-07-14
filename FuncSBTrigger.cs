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
        public static void Run (
            [ServiceBusTrigger("sbtest", Connection = "ServiceBusConnection")] string inputMessage,
            [ServiceBus("sbouttest", Connection = "ServiceBusConnection")] out string outputMessage
            , FunctionContext context)
        {
            var logger = context.GetLogger<FuncSBTrigger>();
            logger.LogInformation($"C# ServiceBus queue trigger function processed message: {inputMessage}");

            outputMessage = $"Processed message: {inputMessage}";

        }
    }
}
