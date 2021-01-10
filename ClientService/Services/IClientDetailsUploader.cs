using ClientService.Models.Information;
using System.Threading.Tasks;

namespace ClientService.Services
{
    public interface IClientDetailsUploader
    {
        Task UploadClientDetails(ClientDetailsFormInformation clientDetailsForm);
    }
}