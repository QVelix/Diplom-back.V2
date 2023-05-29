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

    public int ContactsId { get; set; }

    public int CompaniesId { get; set; }

    public int CompaniesCompanyTypesId { get; set; }

    public int Responsible { get; set; }

    public int UsersUserTypesId { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
