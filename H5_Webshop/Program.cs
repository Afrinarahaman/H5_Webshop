using H5_Webshop.Database;
using H5_Webshop.Repositories;
using H5_Webshop.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();

// Add services to the container.
builder.Services.AddDbContext<WebshopApiContext>(
                o => o.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
app.UseHttpsRedirection();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

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
