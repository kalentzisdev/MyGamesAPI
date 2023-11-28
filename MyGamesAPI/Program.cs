using Microsoft.EntityFrameworkCore;
using MyGamesAPI.Data;
using MyGamesAPI.Mappings;
using MyGamesAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//dependancy injection dbContext
builder.Services.AddDbContext<MyGamesApiDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("MyGamesConnectionString")));

//dependancy injection Studio Repository
builder.Services.AddScoped<IStudioRepository, SQLStudioRepository>();

//dependancy injection Game Repository
builder.Services.AddScoped<IGameRepository, SQLGamesRepository>();


builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

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
