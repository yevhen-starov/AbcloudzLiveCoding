namespace Abcloudz.WebAPI.ViewModels
{
    public class UserDocumentContentViewModel
    {
        public string FileName { get; set; } = default!;
        public Stream Content { get; set; } = default!;
    }
}
