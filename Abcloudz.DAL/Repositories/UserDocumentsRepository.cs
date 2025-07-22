using Abcloudz.Core.Interfaces;
using Abcloudz.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Abcloudz.DAL.Repositories
{
    public class UserDocumentsRepository : BaseRepository<UserDocumentModel, Guid>, IUserDocumentsRepository
    {
        public UserDocumentsRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<UserDocumentModel>> GetUserDocumentsAsync(int userId)
        {
            return await _dbContext.UserDocuments
                .AsNoTracking()
                .Where(d => d.UserId == userId)
                .ToListAsync();
        }
    }
}
