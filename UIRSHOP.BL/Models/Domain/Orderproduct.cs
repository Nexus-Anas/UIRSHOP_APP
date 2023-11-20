using System;
using System.Collections.Generic;

namespace UIRSHOP.DAL;

public partial class Orderproduct
{
    public int Id { get; set; }

    public int Qty { get; set; }

    public int ProductId { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
