using System;
using System.Collections.Generic;

namespace Diplom_back.Models;

public partial class BankRequisite
{
    public int Id { get; set; }

    public string ShortName { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string? Address { get; set; }

    public string Bic { get; set; } = null!;

    public string Rs { get; set; } = null!;

    public string Ks { get; set; } = null!;

    public int RequisitesId { get; set; }

    public virtual Requisite Requisites { get; set; } = null!;
}
