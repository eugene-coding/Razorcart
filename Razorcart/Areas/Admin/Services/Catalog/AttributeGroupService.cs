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
}
