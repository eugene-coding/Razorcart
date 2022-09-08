using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;

using Razorcart.Areas.Admin.DTO.Catalog;
using Razorcart.Areas.Admin.Services.Catalog;
using Razorcart.Areas.Admin.Services.Settings;
using Razorcart.Common;
using Razorcart.Data;

namespace Razorcart.Areas.Admin.Pages.Catalog.AttributeGroup;

public class IndexModel : PageModel
{
    private readonly ISettingService _settingService;
    private readonly IAttributeGroupService _attributeGroupService;

    public IndexModel(
        IStringLocalizer<IndexModel> text,
        LinkGenerator linkGenerator,
        ISettingService settingService,
        IAttributeGroupService attributeGroupService)
    {
        _settingService = settingService;
        _attributeGroupService = attributeGroupService;

        Text = text;
        LinkGenerator = linkGenerator;
        AttributeGroups = new List<AttributeGroupDTO>();
        Breadcrumbs = new List<Breadcrumb>();
    }

    public IStringLocalizer<IndexModel> Text { get; init; }
    public LinkGenerator LinkGenerator { get; init; }

    [BindProperty(SupportsGet = true)]
    public int? PageNumber { get; set; }

    public IEnumerable<Breadcrumb> Breadcrumbs { get; private set; }
    public IReadOnlyCollection<AttributeGroupDTO> AttributeGroups { get; private set; }

    public async Task OnGetAsync()
    {
        Breadcrumbs = new List<Breadcrumb>()
        {
            new ("Главная", LinkGenerator.GetPathByPage(HttpContext, "/Index")),
            new (Text["HeadingTitle"], Request.Path + Request.QueryString)
        };

        var itemsPerPage = await _settingService.GetItemsPerPageAsync();

        FilterData filterData = PageNumber.HasValue 
            ? new(itemsPerPage, PageNumber.Value) 
            : new(itemsPerPage);

        AttributeGroups = await _attributeGroupService.GetAttributeGroupsAsync(filterData);
    }

    public async Task<RedirectToPageResult> OnPostDeleteAsync(int id)
    {
        await _attributeGroupService.DeleteAttributeGroupAsync(id);

        return RedirectToPage();
    }
}
