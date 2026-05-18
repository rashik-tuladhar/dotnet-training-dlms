using LibrarySystem.Business.AuthorBusiness;
using LibrarySystem.Business.BookBusiness;
using LibrarySystem.Repository.AuthorRepository;

using LibrarySystem.Business.CategoryBuisness;


using LibrarySystem.Business.PublicationBusiness;
using LibrarySystem.Repository.BookRepository;

using LibrarySystem.Repository.CategoryRepository;

using LibrarySystem.Business.LocationBusiness;
using LibrarySystem.Repository.LocationRepository;
using LibrarySystem.Repository.Data;
using LibrarySystem.Repository.PublicationRepository;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Repository.MemberRepository;
using LibrarySystem.Business.MemberBusiness;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddScoped<IBookBusiness, BookBusiness>();
builder.Services.AddScoped<ILocationBusiness, LocationBusiness>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IAuthorBusiness, AuthorBusiness>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<ICategoryBusiness, CategoryBuisness>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<IPublicationBusiness, PublicationBusiness>();
builder.Services.AddScoped<IPublicationRepository, PublicationRepository>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddScoped<IPublicationBusiness, PublicationBusiness>();
builder.Services.AddScoped<IPublicationRepository, PublicationRepository>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IMemberBusiness, MemberBusiness>();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
 options.UseSqlite(connectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Member}/{action=AddMembers}/{id?}")
    .WithStaticAssets();


app.Run();
