using Razorcart.Data;
using Razorcart.Data.Models;

namespace Razorcart.Areas.Admin.Services.Catalog;

public interface IAttributeGroupService
{
    Task<List<AttributeGroup>> GetAttributeGroupsAsync();
    Task<List<AttributeGroup>> GetAttributeGroupsAsync(FilterData filterData);
    Task DeleteAttributeGroupAsync(int id);
}
