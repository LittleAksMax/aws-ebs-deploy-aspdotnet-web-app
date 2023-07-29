namespace App.Infrastructure;

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