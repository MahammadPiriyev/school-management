using Microsoft.EntityFrameworkCore;
using School.DataAccess.Data;
using Microsoft.AspNetCore.Identity;
using School.DataAccess.Repository.IRepository;
using School.DataAccess.Repository;
using School.Utility;
using Microsoft.AspNetCore.Identity.UI.Services;
using StackExchange.Redis;
using School.Business.Abstract;
using School.Business.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options
    .UseLazyLoadingProxies()
    .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddRazorPages();
//Add repo
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<IParentRepository, ParentRepository>();
builder.Services.AddScoped<IClassRepository, ClassRepository>();
//Add business services
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<IParentService, ParentService>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
	options.Tokens.EmailConfirmationTokenProvider = "Default";
	options.Tokens.PasswordResetTokenProvider = "Default";
	options.Tokens.ChangeEmailTokenProvider = "Default";
})
.AddDefaultTokenProviders()
.AddEntityFrameworkStores<ApplicationDbContext>(); 
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.ConfigureApplicationCookie(options =>
{
	options.LoginPath = "/Identity/Account/Login";
	options.AccessDeniedPath = "/Identity/Account/AccessDenied";
});

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
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{area=Admin}/{controller=Dashboard}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
