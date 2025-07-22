using Abcloudz.Core.Interfaces;
using Abcloudz.DAL.Interfaces;
using Abcloudz.Models.Models;
using Abcloudz.WebAPI.ViewModels;
using MediatR;

namespace Abcloudz.WebAPI.Application.Commands.UserDocuments.DownloadUserDocument
{
    public record DownloadUserDocumentQuery(Guid DocumentId) : IRequest<UserDocumentContentViewModel>;

    public class DownloadUserDocumentQueryHandler : IRequestHandler<DownloadUserDocumentQuery, UserDocumentContentViewModel>
    {
        private readonly IBaseRepository<UserDocumentModel, Guid> _documentsRepository;
        private readonly IStorageProvider _storageProvider;

        public DownloadUserDocumentQueryHandler(IBaseRepository<UserDocumentModel, Guid> documentsRepository, IStorageProvider storageProvider)
        {
            _documentsRepository = documentsRepository;
            _storageProvider = storageProvider;
        }

        public async Task<UserDocumentContentViewModel> Handle(DownloadUserDocumentQuery request, CancellationToken cancellationToken)
        {
            var document = await _documentsRepository.GetByIdAsync(request.DocumentId, cancellationToken);
            if (document == null)
                throw new FileNotFoundException($"Document with id {request.DocumentId} not found.");

            var fileContent = await _storageProvider.GetFileAsync(document.FilePath, cancellationToken);
            if (fileContent == null)
                throw new FileNotFoundException($"File at {document.FilePath} not found.");

            return new UserDocumentContentViewModel
            {
                FileName = Path.GetFileName(document.FilePath),
                Content = fileContent
            };
        }
    }
}
