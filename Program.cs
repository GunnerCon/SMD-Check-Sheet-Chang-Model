using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using SMDCheckSheet.Data;
using SMDCheckSheet.Services;

var builder = WebApplication.CreateBuilder(args);

// Đăng ký các dịch vụ cần thiết

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
builder.Services.AddScoped<TimeChangeModelService>();
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<ChangeModelService>();
builder.Services.AddScoped<CheckModelService>();
builder.Services.AddScoped<PQCCheckService>();
builder.Services.AddScoped<ProgramCheckService>();
builder.Services.AddScoped<StandardProductionService>();
builder.Services.AddScoped<StandardVehicleService>();


builder.Services.AddEndpointsApiExplorer(); // Cho Swagger
builder.Services.AddSwaggerGen();           // Tích hợp Swagger

var app = builder.Build();

// Cấu hình middleware
    app.UseSwagger();       // Tạo tài liệu Swagger
    app.UseSwaggerUI();     // Hiển thị giao diện Swagger



app.UseHttpsRedirection();  // Chuyển hướng HTTPS
app.UseAuthorization();     // Xác thực nếu có

app.MapControllers();       // Ánh xạ các controller

app.Run();                  // Khởi chạy ứng dụng
