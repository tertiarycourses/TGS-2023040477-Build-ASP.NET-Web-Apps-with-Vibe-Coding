using System.ComponentModel.DataAnnotations; namespace LocalCRM.Options; public sealed class AppOptions { [Required, EmailAddress] public string SupportEmail { get; set; } = string.Empty; }
