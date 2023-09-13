using PersonApi.Context;
using PersonApi.Implementation.Services;
using PersonApi.Implementations.Repositories;
using PersonApi.Interface.Repositories;
using PersonApi.Interface.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(a => a.AddPolicy("CorePolicy", b => {
    b
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowAnyOrigin();
}));
builder.Services.AddControllers();
//Repositories
builder.Services.AddScoped<IPersonRepository, PersonRepository>();

//Services
builder.Services.AddScoped<IPersonService, PersonService>();

builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("ApplicationContext");
builder.Services.AddDbContext<ApplicationContext>(option => option.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => 
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = 
        "PersonApi", Version = "v1"});
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorePolicy");

app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
