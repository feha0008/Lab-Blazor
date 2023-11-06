using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using BlazorLab2.Data;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using BlazorLab2.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<ArtistService>();
builder.Services.AddSingleton<AlbumService>();
builder.Services.AddSingleton<InstrumentService>();
// Inside ConfigureServices method in Startup.cs
builder.Services.AddHttpClient<GenreService>(client =>
{
    client.BaseAddress = new Uri("https://binaryjazz.us/wp-json/genrenator/"); // Replace with your API base URL
});



builder.Services.AddDbContext<ArtistContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("SQLiteDatabase")));

builder.Services.Configure<InstrumentDatabaseSettings>(builder.Configuration.GetSection("InstrumentDatabase"));




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

