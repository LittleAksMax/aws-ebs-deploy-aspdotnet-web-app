namespace App.Api.Installers;

internal sealed class ControllerInstaller : InstallerSingleton<ControllerInstaller>, IInstaller
{
    public void InstallServices(WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
    }
}