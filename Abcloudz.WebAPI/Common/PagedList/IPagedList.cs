namespace Abcloudz.WebAPI.Common.PagedList
{
	public interface IPagedList<T>
	{
		List<T> Items { get; }
		int PageNumber { get; }
		int PageSize { get; }
		int TotalCount { get; }
		int TotalPages { get; }
		bool HasPreviousPage { get; }
		bool HasNextPage { get; }
	}
}
