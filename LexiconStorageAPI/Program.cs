using LexiconStorageAPI.Services;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("LexiconStorageAPIContext") ?? throw new InvalidOperationException("Connection string 'LexiconStorageAPIContext' not found.");

builder.Services.AddDbContext<LexiconStorageAPIContext>(options => options.UseSqlite(connectionString));
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ProductService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
