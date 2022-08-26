namespace Razorcart.Data.Models;

public class Language
{
    public int Id { get; set; }

    public virtual IList<AttributeGroupDescription> AttributeGroupDescriptions { get; set; } = default!;
}
