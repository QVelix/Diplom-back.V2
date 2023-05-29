using System;
using System.Collections.Generic;

namespace Diplom_back.Models;

public partial class CompaniesHasRequisite
{
    public int CompaniesId { get; set; }

    public int CompaniesCompanyTypesId { get; set; }

    public int RequisitesId { get; set; }

    public int RequisitesRequisiteTypesId { get; set; }

    public virtual Requisite Requisites { get; set; } = null!;
}
