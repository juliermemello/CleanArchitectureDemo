using CleanArchitectureDemo.WebAPI.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLog(builder);
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
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
