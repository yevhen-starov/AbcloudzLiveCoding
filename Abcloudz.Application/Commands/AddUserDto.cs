using System.ComponentModel.DataAnnotations;

namespace Abcloudz.Application.Commands;

public class AddUserDto
{
    [MaxLength(30)]
    public required string Name { get; init; }
    
    [EmailAddress]
    public required string Email { get; init; }
    
    [MinLength(6)]
    public required string Password { get; init; }
}