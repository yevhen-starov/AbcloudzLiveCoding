using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Abcloudz.WebAPI.Queries;

public class UserInfoFilterModel
{
    [Range(1, int.MaxValue)]
    [DefaultValue(1)]
    public int Page { get; init; }

    [Range(1, int.MaxValue)]
    [DefaultValue(5)]
    public int PageSize { get; init; }
    
    [EmailAddress]
    public string? Email { get; init; }
    
    public int GetSkipRecordsCount() => PageSize * (Page - 1);
}