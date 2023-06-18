using System;
using System.Collections.Generic;

namespace Diplom_back.Models;

public partial class DealsHasProduct
{
    public int Id { get; set; }

    public int? DealId { get; set; }

    public int? ProductsId { get; set; }
}
