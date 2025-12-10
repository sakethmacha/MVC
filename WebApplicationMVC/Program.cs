using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using WebApplicationMVC.Filters;
using WebApplicationMVC.Interfaces.Interfaces;
using WebApplicationMVC.Models.Models;
using WebApplicationMVC.Services.Services;
namespace WebApplicationMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //builder.Services.AddScoped<HumanResultFilter>();
            //builder.Services.AddScoped<CustomAuthorizationFilter>();
            //builder.Services.AddScoped<BlockBefore9AMFilter>();
            //builder.Services.AddScoped<MyExceptionFilter>();
            builder.Services.AddScoped<DataCheckFilter>();
            builder.Services.AddScoped<IEmployeeValidationService, EmployeeValidationService>();

            //builder.Services.AddTransient<IRequestIdService, RequestIdService>();
            builder.Services.AddScoped<IRequestService, RequestIdService>();
           
            //builder.Services.AddScoped<IRequestIdService, RequestIdService>();
            //builder.Services.AddTransient<ICounterService, CounterService>();
            //builder.Services.AddScoped<ICounterService, CounterService>();
            builder.Services.AddSingleton<ICounterService, CounterService>();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Constr")));

            //var conestring = builder.Configuration.GetConnectionString("Constr");
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IOrderService, OrderService>();


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login";   // redirect here if not logged in
                });


            //builder.Services.AddAuthorization();
            builder.Services.AddSession();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                //The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSession();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseTrafficLogger();

            app.UseRouting();

            // app.UseAuthorization();

            app.UseAuthentication();

            app.UseAuthorization();
            // app.MapControllers();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.Run();
        }
    }
}
