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

    public int CompaniesId { get; set; }

    public int CompaniesCompanyTypesId { get; set; }

    public int Responsible { get; set; }

    public int UsersUserTypesId { get; set; }

    public virtual User User { get; set; } = null!;
}
