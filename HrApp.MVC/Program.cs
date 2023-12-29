using AspNetCoreHero.ToastNotification.Extensions;
using HrApp.MVC;
using HrApp.MVC.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddMVCDependencies();
builder.Services.AddControllersWithViews();
GlobalOptions.Initialize(builder.Configuration);
var app = builder.Build();
app.UseNotyf();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment() && app.Environment.ApplicationName != "Staging")
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

app.Run();
