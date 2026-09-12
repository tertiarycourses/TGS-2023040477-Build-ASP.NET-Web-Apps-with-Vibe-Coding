using LocalCRM.Models;
namespace LocalCRM.Services;
public interface IContactStore
{
    Task<IReadOnlyList<Contact>> ListAsync(CancellationToken ct);
    Task<Contact?> GetAsync(int id, CancellationToken ct);
    Task<Contact> AddAsync(Contact contact, CancellationToken ct);
}
