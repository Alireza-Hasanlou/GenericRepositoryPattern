using GenericRepositoryPattern.Context;
using GenericRepositoryPattern.Services;
using Microsoft.EntityFrameworkCore;

namespace GenericRepositoryPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<MyContext>(option =>
            {
                option.UseSqlServer("Server=.;Database=GenericRepositoryPattern_DB;Trusted_Connection=True;TrustServerCertificate=True;");
            });
            builder.Services.AddTransient<IProductService , ProductService>();
            builder.Services.AddTransient<ICategoryService, CategoryService>(); 
            var app = builder.Build();

    
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");

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
}
