using Abcloudz.WebAPI.DataLayer.DTOs;

namespace Abcloudz.WebAPI.BusinessLayer.Abstractions
{
	public interface IFileService
	{
		void SaveToFile(string filename, string content);
		Task<byte[]> SaveUsersToFileAsync(string filename, List<UserGetDto> users);
	}
}
