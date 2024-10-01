using DEPI_Propject_Company_System.Data;
using DEPI_Propject_Company_System.Models;
using DEPI_Propject_Company_System.Repositoories;
using DEPI_Propject_Company_System.Repositoories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DEPI_Propject_Company_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var constr = builder.Configuration.GetConnectionString("constr")
                    ?? throw new InvalidOperationException("No Connection String");

            builder.Services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(constr);
            });

            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<ICRUD<Department>, CRUD<Department>>();
            builder.Services.AddScoped<ICRUD<Dependent>, CRUD<Dependent>>();
            builder.Services.AddScoped<ICRUD<Employee>, CRUD<Employee>>();
            builder.Services.AddScoped<ICRUD<EmployeeProjects>, CRUD<EmployeeProjects>>();
            builder.Services.AddScoped<ICRUD<Project>, CRUD<Project>>();

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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
