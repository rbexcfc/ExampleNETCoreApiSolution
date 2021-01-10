using Azure.Storage.Blobs;
using ClientService.Exceptions;
using ClientService.Models;
using ClientService.Models.Information;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace ClientService.Services
{
    public class ClientDetailsUploader : IClientDetailsUploader
    {
        private readonly BlobContainerClient _containerClient;
        private readonly BlobStorageConfiguration _blobStorageConfiguration;

        public ClientDetailsUploader(IOptions<BlobStorageConfiguration> blobStorageConfigurationOptions)
        {
            _blobStorageConfiguration = blobStorageConfigurationOptions.Value;
            _containerClient = new BlobContainerClient(_blobStorageConfiguration.ConnectionString, _blobStorageConfiguration.ContainerName);
            _containerClient.CreateIfNotExists();
        }

        public async Task UploadClientDetails(ClientDetailsFormInformation clientDetailsForm)
        {
            try
            {
                using var stream = clientDetailsForm.ClientDetailsForm.OpenReadStream();
                await _containerClient.UploadBlobAsync(clientDetailsForm.ClientDetailsForm.FileName, stream);
            }       
            catch (Azure.RequestFailedException)
            {
                //In the real world log this to App Insights and handle the eror gracefully.
                throw new BlobExistsException($"The following file has already been uploaded ({clientDetailsForm.ClientDetailsForm.FileName})");
            }
        }
    }
}
