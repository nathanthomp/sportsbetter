using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Use swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SportsBetter API", Description = "Real-time Sports Data", Version = "v1" });
});

var app = builder.Build();

// Use swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SportsBetter API V1");
});

app.MapGet("/", () => "SportsBetter default endpoint");

app.Run();