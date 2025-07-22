using Abcloudz.Core.Interfaces;

namespace Abcloudz.Core.Services.FileStorages
{
    public class FileSystemStorageProvider : IStorageProvider
    {
        public async Task SaveFileAsync(string path, Stream content, CancellationToken ct = default)
        {
            var directory = Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            using var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
            await content.CopyToAsync(fileStream, ct);
        }

        public Task<bool> FileExistsAsync(string path, CancellationToken ct = default)
        {
            return Task.FromResult(File.Exists(path));
        }

        public Task DeleteFileAsync(string path, CancellationToken ct = default)
        {
            if (File.Exists(path))
                File.Delete(path);

            return Task.CompletedTask;
        }

        public Task<Stream?> GetFileAsync(string path, CancellationToken ct = default)
        {
            if (!File.Exists(path))
                return Task.FromResult<Stream?>(null);

            var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            return Task.FromResult<Stream?>(stream);
        }
    }
}
