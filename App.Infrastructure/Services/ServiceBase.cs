using App.DataAccess;

namespace App.Infrastructure.Services;

public abstract class ServiceBase
{
    protected AppDbContext Context;

    protected ServiceBase(AppDbContext context)
    {
        Context = context;
    }
}