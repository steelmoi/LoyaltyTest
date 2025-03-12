using loyaltytest.Infrastructure;
using loyaltytest.Infrastructure.Database.Interfaces;
using loyaltytest.Infrastructure.Database.Repository;
using LoyaltyTest.Server.Utils.Interfaces;
using LoyaltyTest.Server.Utils.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LoyaltyDBContext>(optionsAction: options =>
    options.UseSqlServer(
        connectionString: builder.Configuration.GetConnectionString(name: "DBConnectionString")
    )
);

//Add dependency injections
builder.Services.AddScoped<IStoreRepository, StoreRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IAdressRepository, AdressRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IAddressStoreRepository, AddressStoreRepository>();
builder.Services.AddScoped<IFileRepository, FileRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
//End


builder.Services.AddControllers()
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler
                = ReferenceHandler.IgnoreCycles);

builder.Services.AddCors(policy =>
{
    policy.AddPolicy("CorsPolicy", opt => opt
    .AllowAnyOrigin().AllowAnyMethod()
    .AllowAnyHeader()
    );
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Upload")),
    RequestPath = new PathString("/Upload")
});

app.MapFallbackToFile("/index.html");

app.Run();
