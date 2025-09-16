using BookStoreApp.Data;
using BookStoreApp.Domain.Interfaces;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IBookRepository, BookRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    Console.WriteLine("This is development environment");
}
else if (app.Environment.IsStaging())
{
    Console.WriteLine("This is staging environment");
}
else if (app.Environment.IsProduction())
{
    Console.WriteLine("This is production environment");
}
else if (app.Environment.IsEnvironment("Testing"))
{
    Console.WriteLine("This is testing environment");
}

// prvi način

//var connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Algebra;Trusted_Connection=true;";

var connectionString = app.Configuration.GetConnectionString("DefaultConnection");
var connection = new SqlConnection(connectionString);

//await connection.OpenAsync();
connection.Open();
// TODO....
connection.Close();
connection.Dispose();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
