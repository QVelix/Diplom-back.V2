using System;
using System.Collections.Generic;

namespace Diplom_back.Models;

public partial class RequisiteType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Requisite> Requisites { get; set; } = new List<Requisite>();
}
