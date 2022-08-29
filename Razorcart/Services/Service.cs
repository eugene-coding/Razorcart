using Razorcart.Data;

namespace Razorcart.Services;

public abstract class Service
{
    public Service(Context context)
    {
        Context = context;
    }

    private protected Context Context { get; init; }
}
