
using Guild.Data;
using Guild.Repository.Implementation;
using Guild.Repository.IRepository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//To use session 
builder.Services.AddSession();


//To use cookies 
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
      
        options.LoginPath = "/Register/Login";
        
        options.AccessDeniedPath = "/Forbidden/";
    });



//Add services to the container 

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<IRegisterRepository,RegisterRepository>();



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

//To use session include
app.UseSession();
app.UseAuthorization();
//this is also added
app.UseAuthentication();

//Admin area section.
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "MyArea",
      pattern: "{area:exists}/{controller=Admin}/{action=AdminPanel}/{id?}"
    );
});

//Admin Area section ends.

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Guild}/{action=Index}/{id?}");

app.Run();
