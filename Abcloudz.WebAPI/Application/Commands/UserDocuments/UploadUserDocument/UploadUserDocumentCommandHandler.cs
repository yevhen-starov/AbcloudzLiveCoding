using Abcloudz.Core.Interfaces;
using MediatR;

namespace Abcloudz.WebAPI.Application.Commands.UserDocuments.UploadUserDocument
{
    public record UploadUserDocumentCommand(int UserId, string FileName, Stream Content) : IRequest<string>;

    public class UploadUserDocumentCommandHandler : IRequestHandler<UploadUserDocumentCommand, string>
    {
        private readonly IUserDocumentService _userDocumentService;

        public UploadUserDocumentCommandHandler(IUserDocumentService userDocumentService)
        {
            _userDocumentService = userDocumentService;
        }

        public async Task<string> Handle(UploadUserDocumentCommand request, CancellationToken cancellationToken)
        {
            return await _userDocumentService.SaveUserDocumentAsync(request.UserId, request.FileName, request.Content, cancellationToken);
        }
    }
}
