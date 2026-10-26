using Microsoft.AspNetCore.Builder;
using Acme.Admin;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
builder.Environment.ContentRootPath = GetWebProjectContentRootPathHelper.Get("Acme.Admin.Web.csproj"); 
await builder.RunAbpModuleAsync<AdminWebTestModule>(applicationName: "Acme.Admin.Web");

public partial class Program
{
}
