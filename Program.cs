using CatalogoDeProdutos.Infrastucture;
using Microsoft.EntityFrameworkCore;
using ProductsCatalog.Application.Contracts;
using ProductsCatalog.Infrastucture.ProductsRepositories;
using ProductsCatalog.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



string connection = builder.Configuration.GetConnectionString("connection") ?? throw new ArgumentNullException();

builder.Services.AddDbContext<ApiContext>(opt => opt.UseMySql(connection, ServerVersion.AutoDetect(connection)));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IProductRepository, ProductsRepository>();

builder.Services.AddScoped<IProductService, ProductService>();


builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseAuthorization();

app.MapControllers();

app.Run();
