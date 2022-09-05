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

        Language russian = CreateLanguageIfNotFound(context, nameof(russian));

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

        if (!context.Settings.Any())
        {
            context.Add(
                new Setting
                {
                    Area = Area.Admin,
                    Code = Code.Config,
                    Key = "itemsPerPage",
                    Value = "2"
                });
        }

        context.SaveChanges();
    }

    private static Language CreateLanguageIfNotFound(Context context, string name)
    {
        if (!context.Languages.Any(l => l.Name == name))
        {
            context.Languages.Add(new Language
            {
                Name = name
            });

            context.SaveChanges();
        }

        var language = context.Languages.Single(l => l.Name == name);

        return language;
    }
}
