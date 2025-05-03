using demo.datalayer.data;
using demo.datalayer.data.repositry.classes;
using demo.datalayer.data.repositry.interfaceies;
using demo.bl.services.interfaces;
using demo.bl.services.classes;
using Microsoft.EntityFrameworkCore;
using demo.datalayer.data.repositry.Interface;
using demo.datalayer.data.repositries.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Register DbContext
builder.Services.AddDbContext<appdbcontext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.UseLazyLoadingProxies(); 
});

// Register services
builder.Services.AddScoped<idepartmentrepository, departmentrepo>();
builder.Services.AddScoped<iemployeerepo, emprepo>();
builder.Services.AddScoped<iemployeeservice, Employeeservice>();

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<Iunitofwork, unitofwork>();

var app = builder.Build();

// Middleware and routing
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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

app.Run();
