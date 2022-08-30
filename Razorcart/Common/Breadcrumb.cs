namespace Razorcart.Common;

public struct Breadcrumb
{
    public Breadcrumb(string name, string? url)
    {
        url ??= string.Empty;

        Name = name;
        Url = new Uri(url, UriKind.RelativeOrAbsolute);
    }

    public Breadcrumb(string name, Uri url)
    {
        Name = name;
        Url = url;
    }

    public string Name { get; set; }
    public Uri Url { get; set; }
}
