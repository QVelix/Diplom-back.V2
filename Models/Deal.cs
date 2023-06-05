using System;
using System.Collections.Generic;

namespace Diplom_back.Models;

public partial class Deal
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Number { get; set; }

    public decimal? Price { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? CloseDate { get; set; }

    public int UsersId { get; set; }

    public int ContactsId { get; set; }

    public int CompaniesId { get; set; }

    public virtual Company Companies { get; set; } = null!;

    public virtual Contact Contacts { get; set; } = null!;

    public virtual User Users { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
