using System;
using System.Collections.Generic;

namespace Diplom_back.Models;

public partial class Deal
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Number { get; set; }

    public decimal? Price { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? CloseDate { get; set; }

    public int UserId { get; set; }

    public int? CompanyId { get; set; }

    public int? ContactId { get; set; }
}
