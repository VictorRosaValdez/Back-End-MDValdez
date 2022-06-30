using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SimplePondres.Dal;
using SimplePondres.Dal.Repositories;
using SimplePondres.Interfaces;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // SwaggerDoc from the Microsoft documentation.
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Simple Pondres",
        Version = "v1",
        Description = "Manage paper order Application",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Victor",
            Url = new Uri("https://github.com/VictorRosaValdez")
        },
        License = new OpenApiLicense
        {
            Name = "Orders",
            Url = new Uri("https://www.pondres.nl")
        }
    });
    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

//connectionstring from appsetting.json.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Injection of the DbContext.
builder.Services.AddDbContext<SimplePondresDbContext>(x => x.UseSqlServer(connectionString));

// Injection of AutoMapper.
builder.Services.AddAutoMapper(typeof(Program));

// Injection of ProductRepository
builder.Services.AddScoped<IProductRepository,ProductRepository>();

// Injection of OrderRepository
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

// Injection of CompanyRepository
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();

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
