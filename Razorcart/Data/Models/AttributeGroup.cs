namespace Razorcart.Data.Models;

public class AttributeGroup
{
    public int Id { get; set; }
    public int SortOrder { get; set; }
    public bool Enabled { get; set; }

    public virtual IList<AttributeGroupDescription> AttributeGroupDescriptions { get; set; } = default!;
}
