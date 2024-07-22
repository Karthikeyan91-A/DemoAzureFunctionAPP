using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

public static class FuncScheduledTrigger
{
    [Function("FuncScheduledTrigger")]
    public static async Task Run(
        [TimerTrigger("0 */10 * * * *")] TimerInfo myTimer,
        FunctionContext context)
    {
        var log = context.GetLogger("FuncScheduledTrigger");
        log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

        
        string fileName = $"file_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
        string fileContent = $"This is a file created at {DateTime.Now}";

      
        var stream = new MemoryStream(Encoding.UTF8.GetBytes(fileContent));

        
        string connectionString = Environment.GetEnvironmentVariable("BlobStorageConnection");

    
        BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

        
        string containerName = "logcontainer";
        BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

       
        await containerClient.CreateIfNotExistsAsync();

        
        BlobClient blobClient = containerClient.GetBlobClient(fileName);
        await blobClient.UploadAsync(stream, overwrite: true);

        log.LogInformation($"File {fileName} uploaded to blob storage.");
    }
}
