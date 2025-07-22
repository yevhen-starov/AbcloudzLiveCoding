using Abcloudz.Core.Interfaces;
using Abcloudz.WebAPI.ViewModels;
using MediatR;

namespace Abcloudz.WebAPI.Application.Commands.UserDocuments.GetUserDocument
{
    public record GetUserDocumentsQuery(int UserId) : IRequest<List<UserDocumentDownloadViewModel>>;

    public class GetUserDocumentsQueryHandler : IRequestHandler<GetUserDocumentsQuery, List<UserDocumentDownloadViewModel>>
    {
        private readonly IUserDocumentsRepository _documentsRepository;

        public GetUserDocumentsQueryHandler(IUserDocumentsRepository documentsRepository)
        {
            _documentsRepository = documentsRepository;
        }

        public async Task<List<UserDocumentDownloadViewModel>> Handle(GetUserDocumentsQuery request, CancellationToken cancellationToken)
        {
            var documents = await _documentsRepository.GetUserDocumentsAsync(request.UserId);

            return documents
                .Select(d => new UserDocumentDownloadViewModel
                {
                    DocumentId = d.Id,
                    FileName = Path.GetFileName(d.FilePath),
                    DownloadUrl = $"http://localhost:5249/user/{request.UserId}/documents/{d.Id}/download" //hardcoded for convenience
                })
                .ToList();
        }
    }

}
