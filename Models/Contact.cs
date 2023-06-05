using System;
using System.Collections.Generic;

namespace Diplom_back.Models;

public partial class Contact
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string SecondName { get; set; } = null!;

    public string? LastName { get; set; }

    public string? WorkPhone { get; set; }

    public string? PersonalPhone { get; set; }

    public int UsersId { get; set; }

    public int CompaniesId { get; set; }

    public virtual Company Companies { get; set; } = null!;

    public virtual ICollection<Deal> Deals { get; set; } = new List<Deal>();

    public virtual User Users { get; set; } = null!;
}
