namespace Abcloudz.WebAPI.BusinessLayer.Abstractions
{
	public interface IFileService
	{
		void SaveToFile(string filename, string content);
	}
}
