using System;
using System.Collections.Generic;

namespace UIRSHOP.DAL;

public partial class Supplier
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string? ImagePath { get; set; }

    public string Type { get; set; }

    public string? FacebookUrl { get; set; }

    public string? TwitterUrl { get; set; }

    public string? InstagramUrl { get; set; }

    public string? TikTokUrl { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
