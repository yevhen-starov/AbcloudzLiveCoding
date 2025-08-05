using System.Text.Json.Serialization;

namespace Abcloudz.WebAPI.Common.Filters
{
	public class Filter<TFilter>
	{
		private int _pageSize = 10;
		public int Page { get; set; } = 1;
		public int PageSize
		{
			get => _pageSize;
			set { _pageSize = value <= 0 ? 10 : _pageSize = value; }
		}
		public TFilter? Filters { get; set; }
		public string OrderColumn { get; set; } = string.Empty;
		public OrderSort Order { get; set; } = OrderSort.Desc;
	}

	[JsonConverter(typeof(JsonStringEnumConverter))]
	public enum OrderSort
	{
		Asc,
		Desc
	}
}
