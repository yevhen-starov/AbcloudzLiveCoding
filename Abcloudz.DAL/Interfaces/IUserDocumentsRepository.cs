using Abcloudz.DAL.Interfaces;
using Abcloudz.Models.Models;

namespace Abcloudz.Core.Interfaces
{
    public interface IUserDocumentsRepository : IBaseRepository<UserDocumentModel, Guid>
    {
        Task<List<UserDocumentModel>> GetUserDocumentsAsync(int userId);
    }
}
