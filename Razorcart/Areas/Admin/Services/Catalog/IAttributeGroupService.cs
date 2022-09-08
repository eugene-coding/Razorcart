using Razorcart.Areas.Admin.DTO.Catalog;
using Razorcart.Data;


namespace Razorcart.Areas.Admin.Services.Catalog;

public interface IAttributeGroupService
{
    Task<List<AttributeGroupDTO>> GetAttributeGroupsAsync();
    Task<List<AttributeGroupDTO>> GetAttributeGroupsAsync(FilterData filterData);
    Task DeleteAttributeGroupAsync(int id);
}
