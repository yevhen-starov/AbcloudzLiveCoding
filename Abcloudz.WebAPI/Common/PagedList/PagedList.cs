using Microsoft.EntityFrameworkCore;

namespace Abcloudz.WebAPI.Common.PagedList
{
	public class PagedList<T> : IPagedList<T>
	{
		public PagedList()
		{
			Items = new List<T>();
		}


		public PagedList(IList<T> source, int pageNumber, int pageSize)
		{
			if (pageNumber < 1) pageNumber = 1;
			if (pageSize < 1) pageSize = 10;

			TotalCount = source.Count;
			TotalPages = CalculateTotalPages(TotalCount, pageSize);

			if (pageNumber > TotalPages && TotalPages > 0)
			{
				pageNumber = TotalPages;
			}

			PageSize = pageSize;
			PageNumber = pageNumber;
			Items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
		}

		public PagedList(IEnumerable<T> source, int pageNumber, int pageSize, int totalCount, bool sourceFiltered = false)
		{
			if (pageNumber < 1) pageNumber = 1;
			if (pageSize < 1) pageSize = 10;
			if (totalCount < 0) totalCount = 0;

			TotalCount = totalCount;
			TotalPages = CalculateTotalPages(TotalCount, pageSize);

			if (pageNumber > TotalPages && TotalPages > 0)
			{
				pageNumber = TotalPages;
			}

			PageSize = pageSize;
			PageNumber = pageNumber;

			Items = sourceFiltered
				? source.ToList()
				: source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
		}

		public List<T> Items { get; set; } = new();
		public int PageNumber { get; set; }
		public int PageSize { get; set; }
		public int TotalCount { get; set; }
		public int TotalPages { get; set; }
		public bool HasPreviousPage => PageNumber > 1;
		public bool HasNextPage => PageNumber < TotalPages;

		private static int CalculateTotalPages(int totalCount, int pageSize)
		{
			var totalPages = totalCount / pageSize;
			if (totalCount % pageSize > 0)
				totalPages++;
			return totalPages;
		}

		public static async Task<PagedList<T>> CreateAsync(
			IQueryable<T> source,
			int pageNumber,
			int pageSize,
			CancellationToken cancellationToken = default)
		{
			if (pageNumber < 1) pageNumber = 1;
			if (pageSize < 1) pageSize = 10;

			int totalCount = await source.CountAsync(cancellationToken);
			int totalPages = CalculateTotalPages(totalCount, pageSize);

			if (pageNumber > totalPages && totalPages > 0)
				pageNumber = totalPages;

			var items = await source
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync(cancellationToken);

			return new PagedList<T>
			{
				Items = items,
				PageNumber = pageNumber,
				PageSize = pageSize,
				TotalCount = totalCount,
				TotalPages = totalPages
			};
		}
	}
}
