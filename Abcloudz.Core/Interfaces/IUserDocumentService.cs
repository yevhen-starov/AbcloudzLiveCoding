namespace Abcloudz.Core.Interfaces
{
    public interface IUserDocumentService
    {
        Task<string> SaveUserDocumentAsync(int userId, string fileName, Stream content, CancellationToken ct = default);
    }
}
