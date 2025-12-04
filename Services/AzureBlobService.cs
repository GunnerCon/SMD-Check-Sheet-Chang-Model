 using Azure.Storage.Blobs;

public class AzureBlobService
{
    private readonly BlobContainerClient _container;

    public AzureBlobService(IConfiguration config)
    {
        var connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");
        var containerName = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONTAINER");
        _container = new BlobContainerClient(connectionString, containerName);
    }

    public async Task<string> UploadAsync(string fileName, Stream stream)
    {
        var blobClient = _container.GetBlobClient(fileName);
        await blobClient.UploadAsync(stream, overwrite: true);
        return blobClient.Uri.ToString(); // link để lưu vào model
    }
}
