using Azure.Storage.Blobs;

namespace AssignmentApp.API.Repository.Service;

public class StorageService :IStorageService

{
    private readonly BlobServiceClient _blobServiceClient;
    private readonly IConfiguration _configuration;

    public StorageService(BlobServiceClient blobServiceClient, IConfiguration configuration)
    {
        _blobServiceClient = blobServiceClient;
        _configuration = configuration;
    }
    public void Upload(IFormFile file)
    {
        var containerName = _configuration.GetSection("Storage:ContainerName").Value;
        var containerClient = _blobServiceClient.GetBlobContainerClient("");
        var blobClient = containerClient.GetBlobClient(file.FileName);
        using var stream = file.OpenReadStream();
        blobClient.Upload(stream , true);
    }
}