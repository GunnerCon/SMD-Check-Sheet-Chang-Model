using System.Text;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using SMDCheckSheet.Data;
using SMDCheckSheet.Services;

var builder = WebApplication.CreateBuilder(args);

// Đăng ký các dịch vụ cần thiết
Env.Load(); // Tải biến môi trường từ file .env

builder.Configuration.AddEnvironmentVariables(); // Thêm hỗ trợ biến môi trường

// Kiểm tra JWT_KEY
var jwtKey = Environment.GetEnvironmentVariable("JWT_KEY");
if (string.IsNullOrEmpty(jwtKey))
    Console.WriteLine("⚠️ JWT_KEY is not set. Using default key.");
else if (jwtKey.Length < 32)
    Console.WriteLine("⚠️ JWT_KEY is too short. Must be at least 32 characters.");

var keyBytes = Encoding.UTF8.GetBytes(jwtKey ?? "fallback-key-with-32-characters!!");


// Cấu hình DbContext với SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Cấu hình xác thực JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "SMDCheckSheet",
            ValidAudience = "SMDCheckSheetClient",
            IssuerSigningKey = new SymmetricSecurityKey(keyBytes)
        };
    });
builder.Services.AddControllers();

// Đăng ký các services
builder.Services.AddScoped<JwtTokenService>();
builder.Services.AddScoped<TimeChangeModelService>();
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<ChangeModelService>();
builder.Services.AddScoped<CheckModelService>();
builder.Services.AddScoped<PQCCheckService>();
builder.Services.AddScoped<ProgramCheckService>();
builder.Services.AddScoped<StandardProductionService>();
builder.Services.AddScoped<StandardVehicleService>();
builder.Services.AddScoped<AzureBlobService>();


builder.Services.AddEndpointsApiExplorer(); // Cho Swagger
// Tích hợp Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Nhập token dạng: Bearer {token}"
    });

    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();

// Cấu hình middleware
app.UseSwagger();       // Tạo tài liệu Swagger
app.UseSwaggerUI();     // Hiển thị giao diện Swagger



app.UseHttpsRedirection();  // Chuyển hướng HTTPS
app.UseAuthentication();   // Xác thực người dùng
app.UseAuthorization();     // Xác thực nếu có

app.MapControllers();       // Ánh xạ các controller

app.Run();                  // Khởi chạy ứng dụng
