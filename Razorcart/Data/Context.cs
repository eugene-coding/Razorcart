using Microsoft.EntityFrameworkCore;

namespace Razorcart.Data;

internal sealed class Context : DbContext
{
    public Context(DbContextOptions options) : base(options)
    {
    }
}
