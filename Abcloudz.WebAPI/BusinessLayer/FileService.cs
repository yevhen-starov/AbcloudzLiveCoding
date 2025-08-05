using Abcloudz.WebAPI.BusinessLayer.Abstractions;

namespace Abcloudz.WebAPI.BusinessLayer
{
	public class FileService : IFileService
	{
		public void SaveToFile(string filename, string content)
		{
			File.WriteAllText(filename, content);
		}
	}

}
