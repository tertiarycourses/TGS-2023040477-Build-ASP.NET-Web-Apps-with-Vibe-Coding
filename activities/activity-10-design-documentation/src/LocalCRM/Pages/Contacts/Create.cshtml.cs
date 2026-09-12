using LocalCRM.Models; using LocalCRM.Services; using Microsoft.AspNetCore.Mvc; using Microsoft.AspNetCore.Mvc.RazorPages;
namespace LocalCRM.Pages.Contacts;
public sealed class CreateModel(IContactStore store) : PageModel { [BindProperty] public Contact Input { get; set; }=new(); public void OnGet(){} public async Task<IActionResult> OnPostAsync(){ if(!ModelState.IsValid)return Page(); await store.AddAsync(Input,HttpContext.RequestAborted); return RedirectToPage("./Index"); } }
