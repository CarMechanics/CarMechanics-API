<<<<<<< HEAD
using ProiectColectiv.AppDbContext;
=======
using Microsoft.EntityFrameworkCore;
>>>>>>> origin/UserController
using ProiectColectiv.Data;
using ProiectColectiv.Repositories;
using ProiectColectiv.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ApplicationDbContext>();

<<<<<<< HEAD
builder.Services.AddTransient<IRepository<User>, UserRepository>();
builder.Services.AddScoped<UserService>();


=======
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IUserService, UserService>();


//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("ProiectConnection")));

>>>>>>> origin/UserController
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
