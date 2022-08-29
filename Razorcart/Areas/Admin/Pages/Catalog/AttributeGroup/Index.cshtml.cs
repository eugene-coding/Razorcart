using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;

using Razorcart.Areas.Admin.Services.Catalog;

namespace Razorcart.Areas.Admin.Pages.Catalog.AttributeGroup;

public class IndexModel : PageModel
{
    private readonly IAttributeGroupService _service;

    public IndexModel(IStringLocalizer<IndexModel> text, IAttributeGroupService service)
    {
        _service = service;

        Text = text;
        AttributeGroups = new List<Data.Models.AttributeGroup>();
    }

    public IStringLocalizer<IndexModel> Text { get; init; }
    public IReadOnlyCollection<Data.Models.AttributeGroup> AttributeGroups { get; private set; }

    public async Task OnGetAsync()
    {
        AttributeGroups = await _service.GetAttributeGroupsAsync();
    }
}
