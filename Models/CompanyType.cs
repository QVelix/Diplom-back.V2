using System;
using System.Collections.Generic;

namespace Diplom_back.Models;

public partial class CompanyType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();
}
