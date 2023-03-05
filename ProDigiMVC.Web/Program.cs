using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProDigiMVC.Domain.Interfaces;
using ProDigiMVC.Infrastructure;
using ProDigiMVC.Infrastructure.Repository;
using ProDigiMVC.Application;
using ProDigiMVC.Application.ViewModels.Customer;
using FluentValidation;
using FluentValidation.AspNetCore;
using System.Reflection;

namespace ProDigiMVC.Web
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<Context>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<Context>();

            builder.Services.AddControllersWithViews().AddFluentValidation();

            //===================
            //      AddTransint - za każdym razem podawana jest nowa instancja obiektu
            //      Używamy najczęściej
            //builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
            //      AddScoped - obiekt tworzony jest raz na rządanie tzn. jeżeli w jednym żadaniau
            //      użytkownika przkażemy obiekt np w dwa miejsca na raz, to będa to te same instancje
            //builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            //      AddSingleton - zawsze przekażemy tą samą instancję
            //      Staramy się nie używać
            //builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();
            //    !!!  ↓↓↓↓↓↓↓↓↓↓ <== Możemy stwożyć oddzielną klasę dla tych konfiguracji !!!
            builder.Services.AddApplication();
            builder.Services.AddInfrastructure();
            //===============

            builder.Services.AddTransient<IValidator<NewCustomerVm>, NewCustomerValidator>();
            // FluentValidation, dodanie modelu NewCustomerVm 

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}