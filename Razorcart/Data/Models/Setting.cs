using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;

namespace Razorcart.Data.Models;

[Index(nameof(Code), nameof(Area), nameof(Key), IsUnique = true)]
public class Setting
{
    public int Id { get; set; }
    public Area Area { get; set; }
    public Code Code { get; set; }

    [MaxLength(128)]
    public string Key { get; set; } = string.Empty;

    public string Value { get; set; } = string.Empty;
}

public enum Area
{
    Admin,
    Customer
}

public enum Code
{
    Config
}
