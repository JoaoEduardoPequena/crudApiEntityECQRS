using Application;
using System.Text.Json.Serialization;
using WebAPI.Config;
using Infrastructure.Identity;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using WebAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddRazorPages();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CORS",
                         policy =>
                         {
                             policy.AllowAnyOrigin()
                             .AllowAnyHeader()
                             .AllowAnyMethod();
                         });
});

builder.Services.AddMvc()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
    );

builder.Services.AddApplicationServices();
builder.Services.AddInfraPersistenceServices(builder.Configuration); 
builder.Services.AddInfrastructureIdentity(builder.Configuration);

builder.Services.ConfigureSwagger();

builder.Services.AddTransient<GlobalExceptionHandlerMiddleware>();

builder.Services.AddHsts(opt =>
{
    opt.Preload = true;
    opt.IncludeSubDomains = true;
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI(swagger =>
{
    swagger.SwaggerEndpoint("/swagger/geral/swagger.json", "Geral");

    if (app.Environment.IsProduction())
        swagger.RoutePrefix = string.Empty;
});

app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
app.UseRouting();
app.UseAuthentication();
//app.UseAuthorization();
app.UseCors("CORS");

app.MapControllers();
app.MapRazorPages();

app.Run();
