using Azure.Storage.Blobs;

public class AzureBlobService
{
    private readonly BlobContainerClient _container;

    public AzureBlobService(IConfiguration config)
    {
        var connectionString = Environment.GetEnvironmentVariable("AzureBlobConnectionString");
        var containerName = Environment.GetEnvironmentVariable("AzureBlobContainerName");
        _container = new BlobContainerClient(connectionString, containerName);
    }

    public async Task<string> UploadAsync(string fileName, Stream stream)
    {
        var blobClient = _container.GetBlobClient(fileName);
        await blobClient.UploadAsync(stream, overwrite: true);
        return blobClient.Uri.ToString(); // link để lưu vào model
    }
}
