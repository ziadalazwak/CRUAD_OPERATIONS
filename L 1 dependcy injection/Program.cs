using L_1_dependcy_injection.Data;
using L_1_dependcy_injection.Filters;
using L_1_dependcy_injection.MiddleWares;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options=>options.Filters.Add<LogActivityFilter>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbcontext>(builder => builder.UseSqlServer("SERVER=.;DATABASE=Products;integrated security=true;TRUSTSERVERCERTIFICATE=TRUE;"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}app.UseMiddleware<LimitTimeMiddleware>();


app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<Profiling_Middleware>();

app.MapControllers();

app.Run();
