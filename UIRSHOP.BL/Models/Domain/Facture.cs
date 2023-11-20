using System;
using System.Collections.Generic;

namespace UIRSHOP.DAL;

public partial class Facture
{
    public int Id { get; set; }

    public string Num { get; set; } = null!;

    public DateTime DateFacture { get; set; }

    public decimal TotalAmount { get; set; }

    public int OrderId { get; set; }

    public virtual ICollection<DetailsFacture> DetailsFactures { get; set; } = new List<DetailsFacture>();

    public virtual Order Order { get; set; } = null!;
}
