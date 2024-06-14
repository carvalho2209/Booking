using Booky.Api.Extensions;
using Booky.Api.OpenApi;
using Booky.Application;
using Booky.Infrastructure;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var descriptions = app.DescribeApiVersions();

        foreach (var description in descriptions)
        {
            var url = $"/swagger/{description.GroupName}/swagger.json";
            var name = description.GroupName.ToUpperInvariant();
            options.SwaggerEndpoint(url, name);
        }
    });

    app.ApplyMigrations();

    // REMARK: Uncomment if you want to seed initial data.
    app.SeedData();
}

app.UseHttpsRedirection();

app.UseRequestContextLogging();

app.UseSerilogRequestLogging();

app.UseCustomExceptionHandler();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.Run();