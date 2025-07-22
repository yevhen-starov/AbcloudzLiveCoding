using Abcloudz.Models.Interfaces;

namespace Abcloudz.Models.Models
{
    public class UserDocumentModel : IBaseEntity<Guid>, ICreatable
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public string FilePath { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
