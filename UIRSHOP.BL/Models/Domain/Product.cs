using System;
using System.Collections.Generic;

namespace UIRSHOP.DAL;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public string? ImagePath { get; set; }

    public string? Size { get; set; }

    public string? Color { get; set; }

    public int SupplierId { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<DetailsFacture> DetailsFactures { get; set; } = new List<DetailsFacture>();

    public virtual ICollection<Orderproduct> Orderproducts { get; set; } = new List<Orderproduct>();

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();

    public virtual Supplier Supplier { get; set; } = null!;
}
