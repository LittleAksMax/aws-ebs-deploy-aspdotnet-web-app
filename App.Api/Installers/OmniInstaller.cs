namespace App.Api.Installers;

public sealed class OmniInstaller : IInstaller
{
    private static OmniInstaller? _instance; // defaults to null

    public void InstallServices(WebApplicationBuilder builder)
    {
        new DataAccessInstaller().InstallServices(builder);
        // new ServiceInstaller().InstallServices(builder); // this would throw exception before being implemented
    }

    public static OmniInstaller Get()
    {
        // if (_instance is null)
        // {
        //     _instance = new OmniInstaller();
        // }
        // return _instance;
        
        // the below does the same as the commented above
        return _instance ??= new OmniInstaller();
    }
}