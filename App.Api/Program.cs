using App.Api.Installers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
OmniInstaller.Get().InstallServices(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}

app.UseAuthorization();

app.MapControllers();

app.Run();
