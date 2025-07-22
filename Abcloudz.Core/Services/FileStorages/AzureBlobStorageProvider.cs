using Abcloudz.Core.Interfaces;

namespace Abcloudz.Core.Services.FileStorages
{
    //Potentially use blob storage to operate files
    public class AzureBlobStorageProvider : IStorageProvider
    {
        public Task DeleteFileAsync(string path, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> FileExistsAsync(string path, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<Stream?> GetFileAsync(string path, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task SaveFileAsync(string path, Stream content, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
