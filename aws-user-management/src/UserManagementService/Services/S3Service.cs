using Amazon.S3;
using Amazon.S3.Model;
using System.IO;
using System.Threading.Tasks;
using UserManagementService.Services.Interfaces;

namespace UserManagementService.Services
{
    public class S3Service : IS3Service
    {
        private readonly IAmazonS3 _s3Client;
        private readonly string _bucketName;

        public S3Service(IAmazonS3 s3Client, string bucketName)
        {
            _s3Client = s3Client;
            _bucketName = bucketName;
        }

        public async Task<string> UploadProfilePictureAsync(Stream fileStream, string fileName)
        {
            var putRequest = new PutObjectRequest
            {
                BucketName = _bucketName,
                Key = fileName,
                InputStream = fileStream,
                ContentType = "image/jpeg"
            };

            await _s3Client.PutObjectAsync(putRequest);
            return $"https://{_bucketName}.s3.amazonaws.com/{fileName}";
        }

        public async Task<Stream> GetProfilePictureAsync(string fileName)
        {
            var getRequest = new GetObjectRequest
            {
                BucketName = _bucketName,
                Key = fileName
            };

            using var response = await _s3Client.GetObjectAsync(getRequest);
            return response.ResponseStream;
        }
    }
}