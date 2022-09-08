using Microsoft.EntityFrameworkCore;

using Razorcart.Areas.Admin.DTO.Catalog;
using Razorcart.Areas.Admin.Services.Settings;
using Razorcart.Data;
using Razorcart.Services;

namespace Razorcart.Areas.Admin.Services.Catalog;

public class AttributeGroupService : Service, IAttributeGroupService
{
    private readonly ISettingService _settingService;

    public AttributeGroupService(Context context, ISettingService settingService) : base(context)
    {
        _settingService = settingService;
    }

    public async Task<List<AttributeGroupDTO>> GetAttributeGroupsAsync()
    {
        var query = await GetAttributeGroupQueryAsync();

        var result = await query.ToListAsync();

        return result;
    }

    public async Task<List<AttributeGroupDTO>> GetAttributeGroupsAsync(FilterData filterData)
    {
        var initialQuery = await GetAttributeGroupQueryAsync();

        var orderedQuery = filterData.Order is Order.Ascending
             ? initialQuery.OrderBy(a => a.SortOrder)
             : initialQuery.OrderByDescending(a => a.SortOrder);

        var query = orderedQuery
            .Skip(filterData.Skip)
            .Take(filterData.Take);

        var result = await query.ToListAsync();

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

    private async Task<IQueryable<AttributeGroupDTO>> GetAttributeGroupQueryAsync()
    {
        var languageId = await _settingService.GetLanguageIdAsync();

        var query = Context.AttributeGroups
            .Select(ag => new AttributeGroupDTO
            {
                Id = ag.Id,
                Name = ag.AttributeGroupDescriptions
                    .Single(agd => agd.LanguageId == languageId).Name,
                SortOrder = ag.SortOrder
            });

        return query;
    }
}
