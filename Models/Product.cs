using System;
using System.Collections.Generic;

namespace Diplom_back.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<Deal> Deals { get; set; } = new List<Deal>();
}
