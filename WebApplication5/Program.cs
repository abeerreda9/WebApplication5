using demo.datalayer.data.repositry.classes;
using demo.datalayer.data.repositry.interfaceies;
using demo.bl.dto;
using demo.bl.services.interfaces;
using demo.bl.services.classes;

namespace WebApplication5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
          //  builder.Services.AddScoped<idepartmentrepository, departmentrepositry>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            builder.Services.AddScoped<iemployeerepo, emprepo>();
            //builder.Services.auto(typeof(mapping_profile).Assembly);
            builder.Services.AddScoped<iemployeeservice,Employeeservice>();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
          
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}