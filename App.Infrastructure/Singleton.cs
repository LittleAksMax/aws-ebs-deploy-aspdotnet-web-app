namespace App.Infrastructure;

/// <summary>
/// A basic singleton implementation for the service registration
/// in the API layer.
/// </summary>
/// <typeparam name="T">
/// Any instantiable class that is to be the
/// singleton.
/// </typeparam>
public class Singleton<T> where T : new()
{
    private static T? _instance; // defaults to null

    public static T Get()
    {
        // if (_instance is null)
        // {
        //     _instance = new T();
        // }
        // return _instance;

        // the below does the same as the commented above
        return _instance ??= new T();
    }
}