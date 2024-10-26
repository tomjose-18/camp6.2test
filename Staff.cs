using System;
using System.Collections.Generic;

namespace Camp6_Final_Angular.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public int RoleId { get; set; }

    public virtual ICollection<BackgroundVerification> BackgroundVerifications { get; set; } = new List<BackgroundVerification>();

    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();

    public virtual Login? Login { get; set; }

    public virtual Role Role { get; set; } = null!;
}
