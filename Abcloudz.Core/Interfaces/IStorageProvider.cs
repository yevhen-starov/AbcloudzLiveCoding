namespace Abcloudz.Core.Interfaces
{
    public interface IStorageProvider
    {
        Task SaveFileAsync(string path, Stream content, CancellationToken ct = default);
        Task<bool> FileExistsAsync(string path, CancellationToken ct = default);
        Task DeleteFileAsync(string path, CancellationToken ct = default);
        Task<Stream?> GetFileAsync(string path, CancellationToken ct = default);
    }
}
