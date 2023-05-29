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

    public int CompanyTypesId { get; set; }

    public int Responsible { get; set; }

    public int UsersUserTypesId { get; set; }

    public virtual CompanyType CompanyTypes { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
