using App.Infrastructure.Services;
using App.Infrastructure.Services.Interfaces;

namespace App.Api.Installers;

internal sealed class ServiceInstaller : InstallerSingleton<ServiceInstaller>
{
    public override void InstallServices(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<ITodoService, TodoService>();
    }
}