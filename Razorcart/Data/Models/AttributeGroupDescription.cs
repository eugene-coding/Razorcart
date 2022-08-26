using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;

namespace Razorcart.Data.Models;

[Index(nameof(AttributeGroupId), nameof(LanguageId), IsUnique = true)]
public class AttributeGroupDescription
{
    public int Id { get; set; }
    public int AttributeGroupId { get; set; }
    public int LanguageId { get; set; }

    [MaxLength(64)]
    public string Name { get; set; } = string.Empty;

    public virtual AttributeGroup AttributeGroup { get; set; } = default!;
    public virtual Language Language { get; set; } = default!;
}
