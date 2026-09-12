using System.ComponentModel.DataAnnotations;
namespace LocalCRM.Models;
public sealed class Contact
{
    public int Id { get; set; }
    [Required, StringLength(80)] public string Name { get; set; } = string.Empty;
    [Required, EmailAddress] public string Email { get; set; } = string.Empty;
    [Required] public string Stage { get; set; } = "Lead";
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
}
