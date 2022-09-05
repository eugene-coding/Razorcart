using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

using Razorcart.Areas.Admin.Services.Settings;
using Razorcart.Data;
using Razorcart.Data.Models;
using Razorcart.Services;

namespace Razorcart.Areas.Admin.Services.Catalog;

public class AttributeGroupService : Service, IAttributeGroupService
{
    private readonly ISettingService _settingService;

    public AttributeGroupService(Context context, ISettingService settingService) : base(context)
    {
        _settingService = settingService;
    }

    public async Task<List<AttributeGroup>> GetAttributeGroupsAsync()
    {
        var query = await GetAttributeGroupQueryAsync();

        var result = await query.ToListAsync();

        return result;
    }

    public async Task<List<AttributeGroup>> GetAttributeGroupsAsync(FilterData filterData)
    {
        var initialQuery = await GetAttributeGroupQueryAsync();

        IOrderedQueryable<AttributeGroup>? orderedQuery = filterData.Order is Order.Ascending
            ? initialQuery.OrderBy(a => a.SortOrder)
            : initialQuery.OrderByDescending(a => a.SortOrder);

        var limitedQuery = orderedQuery
            .Skip(filterData.Skip)
            .Take(filterData.Take);

        var result = await limitedQuery.ToListAsync();

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

    private async Task<IIncludableQueryable<AttributeGroup, IEnumerable<AttributeGroupDescription>>> GetAttributeGroupQueryAsync()
    {
        var languageId = await _settingService.GetLanguageIdAsync();

        var query = Context.AttributeGroups
            .Include(ag => ag.AttributeGroupDescriptions
                .Where(agd => agd.LanguageId == languageId));

        return query;
    }
}
