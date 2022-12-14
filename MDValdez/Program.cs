using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MDValdez.Dal;
using MDValdez.Dal.Repositories;
using MDValdez.Interfaces;
using System.Reflection;
using Microsoft.AspNetCore.Builder;

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
        Title = "MD Valdez",
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
            Url = new Uri("https://github.com/VictorRosaValdez")
        }
    });
    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

//connectionstring from appsetting.json.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Injection of the DbContext.
builder.Services.AddDbContext<MDDbContext>(x => x.UseSqlServer(connectionString));

// Injection of AutoMapper.
builder.Services.AddAutoMapper(typeof(Program));

// Injection of ProductRepository
builder.Services.AddScoped<IProductRepository,ProductRepository>();

// Injection of AccountRepository
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

// Injection of OrderRepository
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

// Injection of ShoppingCartRepository
builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200",
                                              "http://localhost:4200")
                                                .AllowAnyHeader()
                                                .AllowAnyMethod();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
