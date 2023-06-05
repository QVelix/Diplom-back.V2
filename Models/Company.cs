using System;
using System.Collections.Generic;

namespace Diplom_back.Models;

public partial class Company
{
    public int Id { get; set; }

    public string ShortName { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public int UsersId { get; set; }

    public int CompanyTypesId { get; set; }

    public virtual CompanyType CompanyTypes { get; set; } = null!;

    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();

    public virtual ICollection<Deal> Deals { get; set; } = new List<Deal>();

    public virtual ICollection<Requisite> Requisites { get; set; } = new List<Requisite>();

    public virtual User Users { get; set; } = null!;
}
