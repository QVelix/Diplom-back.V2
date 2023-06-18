using System;
using System.Collections.Generic;

namespace Diplom_back.Models;

public partial class Requisite
{
    public int Id { get; set; }

    public string ShortName { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string? Inn { get; set; }

    public string? Kpp { get; set; }

    public string? Ogrn { get; set; }

    public string? Okpo { get; set; }

    public int CompanyId { get; set; }

    public int RequisiteTypeId { get; set; }
}
