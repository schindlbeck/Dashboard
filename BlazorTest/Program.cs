using BlazorTest;
using BlazorTest.Services;
using Dash.Data;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddDbContext<DashDbContext>(opt => opt.UseSqlServer(@"Server=(localdb)\\MSSQLLocalDB;Database=Dash;Trusted_Connection=True"));
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<DataService>();

await builder.Build().RunAsync();
