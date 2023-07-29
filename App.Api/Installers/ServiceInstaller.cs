using App.Infrastructure.Services.Interfaces;

namespace App.Api.Installers;

internal sealed class ServiceInstaller : InstallerSingleton<ServiceInstaller>, IInstaller
{
    public void InstallServices(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<ITodoService, ITodoService>();
    }
}