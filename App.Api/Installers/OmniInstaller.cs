namespace App.Api.Installers;

internal sealed class OmniInstaller : InstallerSingleton<OmniInstaller>, IInstaller
{
    public void InstallServices(WebApplicationBuilder builder)
    {
        DataAccessInstaller.Get().InstallServices(builder);
        VersioningInstaller.Get().InstallServices(builder);
        ServiceInstaller.Get().InstallServices(builder); // this would throw exception before being implemented
        ControllerInstaller.Get().InstallServices(builder);
    }
}