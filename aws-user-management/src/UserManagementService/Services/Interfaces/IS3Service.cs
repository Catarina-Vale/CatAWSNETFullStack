using Amazon.S3;
using Amazon.S3.Model;
using System.IO;
using System.Threading.Tasks;

namespace UserManagementService.Services.Interfaces
{
    public interface IS3Service
    {
        public Task<string> UploadProfilePictureAsync(Stream fileStream, string fileName);

        public Task<Stream> GetProfilePictureAsync(string fileName);
    }
}