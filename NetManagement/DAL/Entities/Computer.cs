using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class Computer
{
    public int ComputerId { get; set; }

    public string ComputerName { get; set; } = null!;

    public string? Status { get; set; }

    public int? UsedByMember { get; set; }

    public decimal? CostPerHour { get; set; }

    public virtual Member? UsedByMemberNavigation { get; set; }
}
