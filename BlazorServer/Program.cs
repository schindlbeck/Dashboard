using BlazorServer.Data;
using BlazorServer.Services;
using Dash.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile($"appsettings.{Environment.MachineName}.json", true, true);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<DataService>();

builder.Services.AddHealthChecks().AddDbContextCheck<DashDbContext>();
builder.Services.AddDbContext<DashDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSqlConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/health");
});

app.Run();
