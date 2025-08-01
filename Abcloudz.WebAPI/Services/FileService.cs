using System.IO;
using System.Threading.Tasks;

namespace Abcloudz.WebAPI.Services
{
    public interface IFileService
    {
        Task SaveTextAsync(string path, string content);
        Task<string> ReadTextAsync(string path);
    }

    public class FileService : IFileService
    {
        public async Task SaveTextAsync(string path, string content)
        {
            await File.WriteAllTextAsync(path, content);
        }

        public async Task<string> ReadTextAsync(string path)
        {
            return await File.ReadAllTextAsync(path);
        }
    }
}
