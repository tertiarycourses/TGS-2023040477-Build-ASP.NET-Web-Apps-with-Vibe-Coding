using LocalCRM.Contracts; using LocalCRM.Models; using LocalCRM.Services; using Microsoft.AspNetCore.Mvc;
namespace LocalCRM.Controllers;
[ApiController, Route("api/contacts")]
public sealed class ContactsController(IContactStore store) : ControllerBase
{
    [HttpGet] public async Task<IReadOnlyList<ContactDto>> List(CancellationToken ct)=>(await store.ListAsync(ct)).Select(Map).ToList();
    [HttpGet("{id:int}")] public async Task<ActionResult<ContactDto>> Get(int id,CancellationToken ct){var c=await store.GetAsync(id,ct);return c is null?NotFound():Ok(Map(c));}
    [HttpPost] public async Task<ActionResult<ContactDto>> Create(CreateContactDto input,CancellationToken ct){var c=await store.AddAsync(new Contact{Name=input.Name,Email=input.Email,Stage=input.Stage},ct);var dto=Map(c);return CreatedAtAction(nameof(Get),new{id=c.Id},dto);}
    private static ContactDto Map(Contact c)=>new(c.Id,c.Name,c.Email,c.Stage,c.CreatedAt);
}
