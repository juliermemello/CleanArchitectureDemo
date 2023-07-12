using CleanArchitectureDemo.WebAPI.Configurations;
using log4net.Config;

var builder = WebApplication.CreateBuilder(args);

XmlConfigurator.Configure(new FileInfo("log4net.config"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddGeneralConfiguration(builder.Configuration);
builder.Services.AddSwagger();
builder.Services.AddAPICors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.AddAPICors();
app.AddSwagger();
app.AddMiddleware();
app.MapControllers();
app.Run();
