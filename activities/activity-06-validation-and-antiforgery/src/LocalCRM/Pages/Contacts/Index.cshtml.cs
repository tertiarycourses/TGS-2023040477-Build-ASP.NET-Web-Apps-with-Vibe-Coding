using LocalCRM.Models; using LocalCRM.Services; using Microsoft.AspNetCore.Mvc.RazorPages;
namespace LocalCRM.Pages.Contacts;
public sealed class IndexModel(IContactStore store) : PageModel { public IReadOnlyList<Contact> Items { get; private set; }=[]; public async Task OnGetAsync()=>Items=await store.ListAsync(HttpContext.RequestAborted); }
