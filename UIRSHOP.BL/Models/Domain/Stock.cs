using System;
using System.Collections.Generic;

namespace UIRSHOP.DAL;

public partial class Stock
{
    public int Id { get; set; }

    public decimal Price { get; set; }

    public int Qty { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int ProductId { get; set; }

    public virtual Product Product { get; set; } = null!;
}
