using System;
using System.Collections.Generic;

namespace UIRSHOP.DAL;

public partial class Order
{
    public int Id { get; set; }

    public DateTime DateCreate { get; set; }

    public int ClientId { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual ICollection<Facture> Factures { get; set; } = new List<Facture>();
}
