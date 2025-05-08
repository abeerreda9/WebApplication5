using demo.datalayer.data;
using demo.datalayer.data.repositry.classes;
using demo.datalayer.data.repositry.interfaceies;
using demo.bl.services.interfaces;
using demo.bl.services.classes;
using Microsoft.EntityFrameworkCore;
using demo.datalayer.data.repositry.Interface;
using demo.datalayer.data.repositries.Interfaces;
using demo.bl.services.attachment_service;
using Microsoft.AspNetCore.Identity;
using demo.datalayer.models;

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
builder.Services.AddScoped<Iattachment_service,attachment_service>();
var build = WebApplication.CreateBuilder(args);

// تسجيل الخدمات مثل:
builder.Services.AddControllersWithViews();  // لتسجيل الـ MVC

// يمكنك إضافة أي خدمات أخرى مثل:
builder.Services.AddScoped<iemployeeservice, Employeeservice>();
builder.Services.AddScoped<Iunitofwork, unitofwork>();
//builder.Services.AddScoped<UserManager<appuser>>();
//builder.Services.AddScoped<SignInManager<appuser>>();
//builder.Services.AddScoped<RoleManager<IdentityRole>>();
builder.Services.AddIdentity<appuser,IdentityRole>(
    options =>
    {
        //options.User.RequireUniqueEmail = true;
        //options.Password.RequireUppercase = true;
        //options.Password.RequireLowercase = true;
    }
    ).AddEntityFrameworkStores<appdbcontext>().AddDefaultTokenProviders();


var app = builder.Build();


// إعداد الـ Middleware pipeline:

// في حالة بيئة التطوير:
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();  // يظهر صفحة الأخطاء التفصيلية أثناء التطوير
}
else
{
    app.UseExceptionHandler("/Home/Error");  // يعرض صفحة الخطأ العامة في بيئات أخرى
    app.UseHsts();  // يعزز الأمان عبر HSTS (HTTP Strict Transport Security)
}

app.UseHttpsRedirection();  // إعادة توجيه كل الطلبات إلى HTTPS
app.UseStaticFiles();  // يسمح بتقديم الملفات الثابتة (CSS, JS, الصور، إلخ)

// تمكين الـ Routing:
app.UseRouting();  // بدء إعداد المسارات

// إضافة الـ Middleware الخاص بـ Authorization/Authentication إذا لزم الأمر
app.UseAuthentication();  // لتفعيل المصادقة (إن كان هناك حاجة)
app.UseAuthorization();  // لتفعيل التفويض (إن كان هناك حاجة)



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
    pattern: "{controller=account}/{action=register}/{id?}");

app.Run();
