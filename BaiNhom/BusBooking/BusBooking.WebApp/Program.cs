using BusBooking.Data.Contexts;
using BusBooking.Data.Seeders;
using BusBooking.Services.Class;
using BusBooking.Services.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Đăng ký DbContext
builder.Services.AddDbContext<BusDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Đăng ký các dịch vụ
builder.Services.AddScoped<IDataSeeder, DataSeeder>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IRouteService, RouteService>();
builder.Services.AddScoped<IScheduleService, ScheduleService>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();

// Đăng ký MVC + Session
builder.Services.AddControllersWithViews();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Session hết hạn sau 30 phút không hoạt động
    options.Cookie.HttpOnly = true;                // Bảo vệ cookie session
    options.Cookie.IsEssential = true;             // Đảm bảo cookie luôn được gửi
});

var app = builder.Build();

// Seed dữ liệu
using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<IDataSeeder>();
    seeder.Initialize();
}

// Middleware pipeline
app.UseStaticFiles();

app.UseRouting();

app.UseSession();          // 🌟 Bắt buộc để sử dụng Session
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
