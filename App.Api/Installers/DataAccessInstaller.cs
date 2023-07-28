using App.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace App.Api.Installers;

public class DataAccessInstaller : IInstaller
{
    public void InstallServices(WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer();
        });
    }
}