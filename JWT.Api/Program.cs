using DAL;
using Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddServices(builder.Configuration)
    .AddDal(builder.Configuration)
    .AddAuthorization()
    .AddControllers();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

