using DapperTask.Repositories;
using DapperTask.Services;
using Fathy.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSingleton<OrderRepository>();
builder.Services.AddSingleton<IOrderService, OrderService>();

builder.Services.AddSingleton<OrderDetailRepository>();
builder.Services.AddSingleton<IOrderDetailService, OrderDetailService>();

var openApiInfo = new OpenApiInfo
{
    Title = "DapperTask",
    Version = "v1"
};

builder.Services.AddSwaggerService(openApiInfo);

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint($"/swagger/{openApiInfo.Version}/swagger.json", openApiInfo.Title);
});

app.MapControllers();

app.Run();
