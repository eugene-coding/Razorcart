using Microsoft.EntityFrameworkCore;

using Razorcart.Data;
using Razorcart.Data.Models;
using Razorcart.Services;

namespace Razorcart.Areas.Admin.Services.Catalog;

public class AttributeGroupService : Service, IAttributeGroupService
{
    public AttributeGroupService(Context context) : base(context)
    {
    }

    public async Task<List<AttributeGroup>> GetAttributeGroupsAsync()
    {
        var result = await Context.AttributeGroups
            .Include(ag => ag.AttributeGroupDescriptions)
            .ToListAsync();

        return result;
    }

    public async Task DeleteAttributeGroupAsync(int id)
    {
        var attributeGroup = await Context.AttributeGroups
            .SingleOrDefaultAsync(ag => ag.Id == id);

        if (attributeGroup is not null)
        {
            Context.AttributeGroups.Remove(attributeGroup);

            await Context.SaveChangesAsync();
        }
    }
}
