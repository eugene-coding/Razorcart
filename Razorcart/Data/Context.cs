using Microsoft.EntityFrameworkCore;

using Razorcart.Data.Models;

namespace Razorcart.Data;

public class Context : DbContext
{
    public Context(DbContextOptions options) : base(options)
    {
    }

    public DbSet<AttributeGroup> AttributeGroups => Set<AttributeGroup>();
    public DbSet<AttributeGroupDescription> AttributeGroupDescriptions => Set<AttributeGroupDescription>();
    public DbSet<Language> Languages => Set<Language>();
}
