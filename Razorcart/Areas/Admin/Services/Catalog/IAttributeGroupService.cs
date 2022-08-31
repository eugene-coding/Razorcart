using Razorcart.Data.Models;

namespace Razorcart.Areas.Admin.Services.Catalog;

public interface IAttributeGroupService
{
    Task<List<AttributeGroup>> GetAttributeGroupsAsync();
    Task DeleteAttributeGroupAsync(int id);
}
