using App.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace App.Api.Installers;

public sealed class DataAccessInstaller : IInstaller
{
    public void InstallServices(WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration["SqlServer:ConnectionString"];
        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
    }
}