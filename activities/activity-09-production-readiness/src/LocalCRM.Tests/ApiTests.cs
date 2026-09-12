using System.Net; using System.Net.Http.Json; using Microsoft.AspNetCore.Mvc.Testing; using Xunit;
namespace LocalCRM.Tests;
public sealed class ApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient client;
    public ApiTests(WebApplicationFactory<Program> factory) => client = factory.CreateClient();
    [Fact] public async Task Health_is_ready() => Assert.Equal(HttpStatusCode.OK, (await client.GetAsync("/health/ready")).StatusCode);
    [Fact] public async Task Contacts_list_is_json() { var response=await client.GetAsync("/api/contacts"); Assert.Equal(HttpStatusCode.OK,response.StatusCode); Assert.Equal("application/json",response.Content.Headers.ContentType?.MediaType); }
    [Fact] public async Task Invalid_contact_returns_problem_details() { var response=await client.PostAsJsonAsync("/api/contacts",new { name="",email="not-an-email",stage="Lead" }); Assert.Equal(HttpStatusCode.BadRequest,response.StatusCode); Assert.Equal("application/problem+json",response.Content.Headers.ContentType?.MediaType); }
}
