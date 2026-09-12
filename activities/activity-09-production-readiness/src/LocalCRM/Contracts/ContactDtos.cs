using System.ComponentModel.DataAnnotations;
namespace LocalCRM.Contracts;
public sealed record CreateContactDto([Required, StringLength(80, MinimumLength=2)] string Name, [Required, EmailAddress] string Email, [Required] string Stage);
public sealed record ContactDto(int Id, string Name, string Email, string Stage, DateTimeOffset CreatedAt);
