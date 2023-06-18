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

    public int CompanyTypeId { get; set; }

    public int UserId { get; set; }
}
