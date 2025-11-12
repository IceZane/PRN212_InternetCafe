using System;
using System.Collections.Generic;

<<<<<<< HEAD
namespace DAL.Entities;
=======
namespace NetManagement;
>>>>>>> 239f428882aad7dfed972506174d8ec2d52f7e91

public partial class Computer
{
    public int ComputerId { get; set; }

    public string ComputerName { get; set; } = null!;

    public string? Status { get; set; }

    public int? UsedByMember { get; set; }

    public decimal? CostPerHour { get; set; }

    public virtual Member? UsedByMemberNavigation { get; set; }
}
