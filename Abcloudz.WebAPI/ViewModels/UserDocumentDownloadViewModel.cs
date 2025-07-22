namespace Abcloudz.WebAPI.ViewModels
{
    public class UserDocumentDownloadViewModel
    {
        public Guid DocumentId { get; set; }
        public string FileName { get; set; }
        public string DownloadUrl { get; set; }
    }
}
