using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using MyCourse.Models;

var builder = WebApplication.CreateBuilder(args);

var dbPassword = builder.Configuration["SQLite:Password"];
var dbFilename = builder.Configuration["SQLite:Filename"];
var dbFolder = Environment.SpecialFolder.LocalApplicationData;
var dbFolderPath = Environment.GetFolderPath(dbFolder);
var dbPath = System.IO.Path.Join(dbFolderPath, dbFilename);

// builder.Services.AddDbContext<QuizContext>(options => options.UseSqlite($"Data Source={dbPath};Password={dbPassword}"));
builder.Services.AddDbContext<QuizContext>(options => options.UseSqlite($"Data Source={dbPath}"));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IQuizService, EFQuizService>();

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

app.Run();
