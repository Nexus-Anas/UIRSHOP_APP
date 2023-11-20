using System;
using System.Collections.Generic;

namespace UIRSHOP.DAL;

public partial class DetailsFacture
{
    public int Id { get; set; }

    public int FactureId { get; set; }

    public int ProductId { get; set; }

    public decimal ProductPu { get; set; }

    public int ProductQty { get; set; }

    public virtual Facture Facture { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
