namespace Abcloudz.WebAPI.DataLayer.DTOs
{
	public class DownloadUsersRequestDto
	{
		public string Filename { get; set; }
		public List<UserGetDto> Users { get; set; }
	}
}
