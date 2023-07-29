using App.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace App.Api.Installers;

internal sealed class DataAccessInstaller : InstallerSingleton<DataAccessInstaller>, IInstaller
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