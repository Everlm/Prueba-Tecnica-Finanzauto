using Finanzauto.API.Extensions;
using Finanzauto.Application.Extensions;
using Finanzauto.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInjectionInfrastructure(builder.Configuration);
builder.Services.AddInjectionApplication(builder.Configuration);
builder.Services.AddAuthentication(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwagger();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
