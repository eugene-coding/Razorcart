using Microsoft.EntityFrameworkCore;

namespace Razorcart.Data;

public class Context : DbContext
{
    public Context(DbContextOptions options) : base(options)
    {
    }
}
