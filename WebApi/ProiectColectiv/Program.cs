using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

using ProiectColectiv.AppDbContext;
using ProiectColectiv.Data;
using ProiectColectiv.Data.Repositories;
using ProiectColectiv.Services;

using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition(name: "Bearer", securityScheme: new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Enter the Bearer Authorization string as following: `Bearer Generated-JWT-Token`. You need to execute one of the Login methods to get the token.",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        new List<string>()
                    }
                });
});
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(connectionString));

var jwtConfig = builder.Configuration.GetSection("jwtConfig");
var jwtSecret = jwtConfig["secret"];

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOriginsHeadersAndMethods",
        o => o.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtConfig["validIssuer"],
        ValidAudience = jwtConfig["validAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret))
    };
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(o =>
{
    o.Password.RequireDigit = false;
    o.Password.RequireNonAlphanumeric = false;
    o.Password.RequiredLength = 3;
    o.Password.RequireUppercase = false;
    o.Password.RequireLowercase = false;
    o.User.RequireUniqueEmail = false;
})
     .AddEntityFrameworkStores<ApplicationDbContext>()
     .AddDefaultTokenProviders();

builder.Services.AddScoped<IRepository<Car, CarPostDTO>, CarRepository>();
builder.Services.AddScoped<IRepository<Appointment, AppointmentPostDTO>, AppointmentRepository>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddHttpContextAccessor();

builder.Services.Configure<IdentityOptions>(options =>
    options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier);

builder.Services.AddHttpContextAccessor();

// Add configuration from appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Services.AddHttpContextAccessor();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowAllOriginsHeadersAndMethods");
app.MapControllers();

app.Run();
