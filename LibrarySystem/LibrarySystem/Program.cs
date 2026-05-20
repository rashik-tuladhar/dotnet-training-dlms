using LibrarySystem.Business.BookBusiness;
using LibrarySystem.Business.CategoryBusiness;
using LibrarySystem.Business.PublicationBusiness;
using LibrarySystem.Repository.BookRepository;
using LibrarySystem.Repository.CategoryRepository;
using LibrarySystem.Repository.Data;
using LibrarySystem.Repository.PublicationRepository;
using Microsoft.EntityFrameworkCore;

public partial class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

        builder.Services.AddScoped<IBookBusiness, BookBusiness>();
        builder.Services.AddScoped<IBookRepository, BookRepository>();

        builder.Services.AddScoped<ICategoryBusiness, CategoryBusiness>();
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<IPublicationBusiness, PublicationBusiness>();
        builder.Services.AddScoped<IPublicationRepository, PublicationRepository>();

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

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
            pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();


        app.Run();
    }
}