using EventTicketBookingSystemData.Model;
using EventTicketBookingSystemMVC.Service;
using EventTicketBookingSystemMVC.Service.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using OnlineTicketBookingDataAccess.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DatabaseContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection")));
//var connectionString = builder.Configuration.GetConnectionString("DatabaseContextConnection") ?? throw new InvalidOperationException("Connection string 'DatabaseContextConnection' not found.");

//builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer());

builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<DatabaseContext>().AddDefaultTokenProviders();
//builder.Services.AddIdentity<IdentityUser,IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<DatabaseContext>().AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(options => {
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});
builder.Services.AddRazorPages();

// Add services to the container.

builder.Services.AddHttpClient<IEventService, EventService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddTransient<IEventService, EventService>();
builder.Services.AddHttpClient<ITicketBookingService, TicketBookingService>();
builder.Services.AddScoped<ITicketBookingService, TicketBookingService>();
builder.Services.AddHttpClient<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IApprovalService, ApprovalService>();



builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddControllersWithViews();

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
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();