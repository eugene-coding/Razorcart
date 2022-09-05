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
                            LanguageId = russian.Id
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
                            LanguageId = russian.Id
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
                            LanguageId = russian.Id
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
                            LanguageId = russian.Id
                        }
                    },
                    SortOrder = 4,
                    Enabled = true
                });
        }

        if (!context.Settings.Any())
        {
            context.Add(
                new Setting
                {
                    Code = Code.Config,
                    Area = Area.Admin,
                    Key = "itemsPerPage",
                    Value = "20"
                });
        }

        context.SaveChanges();
    }
}
