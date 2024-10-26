using System;
using System.Collections.Generic;

namespace Camp6_Final_Angular.Models;

public partial class Login
{
    public int LoginId { get; set; }

    public int StaffId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual Staff Staff { get; set; } = null!;
}
