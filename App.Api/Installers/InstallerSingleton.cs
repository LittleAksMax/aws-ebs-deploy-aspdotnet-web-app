using App.Infrastructure;

namespace App.Api.Installers;

/// <summary>
/// Singleton to ensure that installers are only instantiated once without having
/// to register them as singletons through DI.
/// </summary>
/// <typeparam name="TInstaller">The type of the installer class that inherits from this class</typeparam>
internal abstract class InstallerSingleton<TInstaller> : Singleton<TInstaller>
    where TInstaller : IInstaller, new()
{
}