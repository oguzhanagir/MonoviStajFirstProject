using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MonoviStajFirstProject.Business.Abstract;
using MonoviStajFirstProject.Business.Concrete;
using MonoviStajFirstProject.Business.ValidationRules.FluentValidation;
using MonoviStajFirstProject.DataAccess.Abstract;
using MonoviStajFirstProject.DataAccess.Concrete;
using MonoviStajFirstProject.Entities.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MonoviStajFirstProjectDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

#region Business Classes
builder.Services.AddTransient(typeof(IUserService), typeof(UserService));

#endregion

#region FluentValidation
builder.Services.AddTransient<IValidator<User>, UserValidatior>();

#endregion




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
