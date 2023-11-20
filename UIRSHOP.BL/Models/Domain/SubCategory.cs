using System;
using System.Collections.Generic;

namespace UIRSHOP.DAL;

public partial class SubCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;
}
