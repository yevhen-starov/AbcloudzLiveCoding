using Abcloudz.Core.Interfaces;

namespace Abcloudz.Core.Services
{
    public class StorageManager : IStorageManager
    {
        private readonly IStorageProvider _storageProvider;

        //Now this is a simplified version but
        //Potentially inject some services for additional logic
        public StorageManager(IStorageProvider storageProvider)
        {
            _storageProvider = storageProvider;
        }

        public Task SaveFileAsync(string path, Stream content, CancellationToken ct = default)
            => _storageProvider.SaveFileAsync(path, content, ct);

        public Task<Stream?> GetFileAsync(string path, CancellationToken ct = default)
            => _storageProvider.GetFileAsync(path, ct);

        public Task DeleteFileAsync(string path, CancellationToken ct = default)
            => _storageProvider.DeleteFileAsync(path, ct);

        public Task<bool> FileExistsAsync(string path, CancellationToken ct = default)
            => _storageProvider.FileExistsAsync(path, ct);
    }
}
