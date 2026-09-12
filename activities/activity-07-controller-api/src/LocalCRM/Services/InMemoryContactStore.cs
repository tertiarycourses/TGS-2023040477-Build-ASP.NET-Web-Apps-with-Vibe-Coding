using LocalCRM.Models;
namespace LocalCRM.Services;
public sealed class InMemoryContactStore : IContactStore
{
    private readonly List<Contact> _items = [
        new() { Id=1, Name="Aisha Rahman", Email="aisha@example.test", Stage="Lead" },
        new() { Id=2, Name="Benjamin Tan", Email="benjamin@example.test", Stage="Qualified" },
        new() { Id=3, Name="Chen Mei", Email="mei@example.test", Stage="Customer" }
    ];
    public Task<IReadOnlyList<Contact>> ListAsync(CancellationToken ct) => Task.FromResult<IReadOnlyList<Contact>>(_items.ToList());
    public Task<Contact?> GetAsync(int id, CancellationToken ct) => Task.FromResult(_items.SingleOrDefault(x => x.Id == id));
    public Task<Contact> AddAsync(Contact c, CancellationToken ct) { c.Id = _items.Max(x => x.Id) + 1; c.CreatedAt=DateTimeOffset.UtcNow; _items.Add(c); return Task.FromResult(c); }
}
