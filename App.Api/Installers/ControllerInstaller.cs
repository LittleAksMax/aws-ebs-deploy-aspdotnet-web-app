namespace App.Api.Installers;

internal sealed class ControllerInstaller : InstallerSingleton<ControllerInstaller>
{
    public override void InstallServices(WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
    }
}