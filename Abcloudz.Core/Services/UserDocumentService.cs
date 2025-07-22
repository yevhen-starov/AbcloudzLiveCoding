using Abcloudz.Core.Interfaces;
using Abcloudz.DAL.Interfaces;
using Abcloudz.Models.Models;

namespace Abcloudz.Core.Services
{
    public class UserDocumentService : IUserDocumentService
    {
        private readonly IStorageProvider _storageProvider;
        private readonly IBaseRepository<UserDocumentModel, Guid> _userDocumentsRepository;

        public UserDocumentService(IStorageProvider storageProvider, IBaseRepository<UserDocumentModel, Guid> userDocumentsRepository)
        {
            _storageProvider = storageProvider;
            _userDocumentsRepository = userDocumentsRepository;
        }

        public async Task<string> SaveUserDocumentAsync(int userId, string fileName, Stream content, CancellationToken ct = default)
        {
            //TODO: Move "user-documents" to config
            var storagePath = Path.Combine("user-documents", userId.ToString(), fileName);

            await _storageProvider.SaveFileAsync(storagePath, content, ct);

            var userDocument = new UserDocumentModel
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                FilePath = storagePath,
                CreatedDate = DateTime.UtcNow
            };

            await _userDocumentsRepository.AddAsync(userDocument, ct);

            return storagePath;
        }
    }
}
