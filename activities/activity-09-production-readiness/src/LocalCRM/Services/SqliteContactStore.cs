using LocalCRM.Data; using LocalCRM.Models; using Microsoft.EntityFrameworkCore;
namespace LocalCRM.Services;
public sealed class SqliteContactStore(CrmDbContext db):IContactStore
{
 public async Task<IReadOnlyList<Contact>> ListAsync(CancellationToken ct)=>await db.Contacts.AsNoTracking().OrderBy(x=>x.Id).ToListAsync(ct);
 public Task<Contact?> GetAsync(int id,CancellationToken ct)=>db.Contacts.AsNoTracking().SingleOrDefaultAsync(x=>x.Id==id,ct);
 public async Task<Contact> AddAsync(Contact c,CancellationToken ct){db.Contacts.Add(c);await db.SaveChangesAsync(ct);return c;}
}
