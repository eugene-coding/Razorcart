using Microsoft.EntityFrameworkCore;

using Razorcart.Data.Models;

namespace Razorcart.Data;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new Context(serviceProvider.GetRequiredService<DbContextOptions<Context>>());

        if (context is null)
        {
            throw new ArgumentNullException("Null Context");
        }

        Language russian = new()
        {
            Id = 1
        };

        if (!context.Languages.Any())
        {
            context.Languages.Add(russian);
        }

        if (!context.AttributeGroups.Any())
        {
            context.AttributeGroups.AddRange(
                new AttributeGroup()
                {
                    AttributeGroupDescriptions = new List<AttributeGroupDescription>
                    {
                        new AttributeGroupDescription
                        {
                            Name = "Память",
                            Language = russian
                        }
                    },
                    SortOrder = 2,
                    Enabled = true
                },
                new AttributeGroup()
                {
                    AttributeGroupDescriptions = new List<AttributeGroupDescription>
                    {
                        new AttributeGroupDescription
                        {
                            Name = "Технические",
                            Language = russian
                        }
                    },
                    SortOrder = 1,
                    Enabled = true
                },
                new AttributeGroup()
                {
                    AttributeGroupDescriptions = new List<AttributeGroupDescription>
                    {
                        new AttributeGroupDescription
                        {
                            Name = "Материнская плата",
                            Language = russian
                        }
                    },
                    SortOrder = 3,
                    Enabled = true
                },
                new AttributeGroup()
                {
                    AttributeGroupDescriptions = new List<AttributeGroupDescription>
                    {
                        new AttributeGroupDescription
                        {
                            Name = "Процессор",
                            Language = russian
                        }
                    },
                    SortOrder = 4,
                    Enabled = true
                });
        }

        context.SaveChanges();
    }
}
