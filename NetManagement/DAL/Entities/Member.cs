using System;
using System.Collections.Generic;

namespace NetManagement;

public partial class Member
{
    public int MemberId { get; set; }

    public string AccountName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string CitizenId { get; set; } = null!;

    public decimal? Money { get; set; }

    public DateTime? DateCreated { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Computer> Computers { get; set; } = new List<Computer>();
}
