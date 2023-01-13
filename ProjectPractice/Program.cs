using Microsoft.DotNet.Scaffolding.Shared.ProjectModel;
using Microsoft.EntityFrameworkCore;
using ProjectPractice.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var PracticetContextconnectionString = builder.Configuration.GetConnectionString("Practice");
builder.Services.AddDbContext<PracticeContext>(options =>
	options.UseSqlServer(PracticetContextconnectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Reports}/{action=Index}/{id?}");

app.Run();
