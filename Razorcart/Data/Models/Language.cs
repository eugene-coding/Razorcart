using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;

namespace Razorcart.Data.Models;

[Index(nameof(Name), IsUnique = true)]
public class Language
{
    public int Id { get; set; }

    [MaxLength(32)]
    public string Name { get; set; } = string.Empty;

    public virtual IList<AttributeGroupDescription> AttributeGroupDescriptions { get; set; } = default!;
}
