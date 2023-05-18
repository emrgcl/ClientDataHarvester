using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ClientDataHarvester.WebApi.Data;
using ClientDataHarvester.WebApi.Models;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

// Add DbContext
services.AddDbContext<ClientDataContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

// Add controllers
services.AddControllers();

// Add Swagger services
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ClientDataHarvester API", Version = "v1" });
});

var app = builder.Build();

// For enforcing HTTPS
app.UseHttpsRedirection();

// Enable middleware to serve generated Swagger as a JSON endpoint.
app.UseSwagger();

// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
// specifying the Swagger JSON endpoint.
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ClientDataHarvester API v1");
});

// Routing
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
