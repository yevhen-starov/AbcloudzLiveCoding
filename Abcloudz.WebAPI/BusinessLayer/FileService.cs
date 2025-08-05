using Abcloudz.WebAPI.BusinessLayer.Abstractions;
using Abcloudz.WebAPI.DataLayer.DTOs;
using System.Text.Json;

namespace Abcloudz.WebAPI.BusinessLayer
{
	public class FileService : IFileService
	{
		public async Task<byte[]> SaveUsersToFileAsync(string filename, List<UserGetDto> users)
		{
			string content = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });

			string tempPath = Path.Combine(Path.GetTempPath(), filename);
			SaveToFile(tempPath, content);

			byte[] fileBytes = await File.ReadAllBytesAsync(tempPath);

			File.Delete(tempPath);

			return fileBytes;
		}

		public void SaveToFile(string filename, string content)
		{
			File.WriteAllText(filename, content);
		}
	}

}
