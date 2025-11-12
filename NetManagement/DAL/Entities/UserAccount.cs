using System;
using System.Collections.Generic;

namespace NetManagement;

public partial class UserAccount
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string CitizenId { get; set; } = null!;

    public string Role { get; set; } = null!;

    public DateTime? DateCreated { get; set; }

    public string? Status { get; set; }
}
