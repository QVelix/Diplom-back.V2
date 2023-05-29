using System;
using System.Collections.Generic;

namespace Diplom_back.Models;

public partial class User
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string SecondName { get; set; } = null!;

    public string? LastName { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string? WorkPhone { get; set; }

    public string? PersonalPhone { get; set; }

    public int UserTypesId { get; set; }

    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();

    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();

    public virtual ICollection<Deal> Deals { get; set; } = new List<Deal>();

    public virtual UserType UserTypes { get; set; } = null!;
}
