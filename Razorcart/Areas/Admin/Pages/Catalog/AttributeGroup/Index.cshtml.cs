using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;

using Razorcart.Areas.Admin.Services.Catalog;
using Razorcart.Common;

namespace Razorcart.Areas.Admin.Pages.Catalog.AttributeGroup;

public class IndexModel : PageModel
{
    private readonly IAttributeGroupService _service;

    public IndexModel(IStringLocalizer<IndexModel> text, LinkGenerator linkGenerator, IAttributeGroupService service)
    {
        _service = service;

        Text = text;
        LinkGenerator = linkGenerator;
        AttributeGroups = default!;
        Breadcrumbs = default!;
    }

    public IStringLocalizer<IndexModel> Text { get; init; }
    public LinkGenerator LinkGenerator { get; init; }

    public IEnumerable<Breadcrumb> Breadcrumbs { get; private set; }
    public IReadOnlyCollection<Data.Models.AttributeGroup> AttributeGroups { get; private set; }

    public async Task OnGetAsync()
    {
        var query = Request.QueryString.ToString();

        Breadcrumbs = new List<Breadcrumb>()
        {
            new ("Главная", LinkGenerator.GetPathByPage(HttpContext, "/Index")),
            new (Text["HeadingTitle"], Request.Path + Request.QueryString)
        };

        AttributeGroups = await _service.GetAttributeGroupsAsync();
    }
}
