using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;

#region AdditionalNamespaces
using ChinookSystem;
#endregion

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Given, supplied database connection due to the fact that we created this web app to use individual accounts
//  Code retrieves the connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//Added, code retrieves the ChinookDB connection string
var connectionStringChinook = builder.Configuration.GetConnectionString("ChinookDB");

// Given, registers the supplied connection string with the IService collection (.Services)
//  This registers a connection string for individual accounts
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Added, code the logic to add our class library services to IServiceCollection 
//      One could do the registration code here in Program.cs, however every time a service class is added
//      you would be changing this file
// The implementation of the DBContent and AddTransient(...) code in this example
//  Will be done in an extension method to IServiceCollection
//  The extension method will be coded inside the ChinookSystem class library
//  the extension method will have a parameter: options.UseSqlServer().
builder.Services.ChinookSystemBackendDependencies(options => options.UseSqlServer(connectionStringChinook));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
