using System;
using System.Collections.Generic;

namespace Camp6_Final_Angular.Models;

public partial class Loan
{
    public int LoanId { get; set; }

    public int CustomerId { get; set; }

    public decimal LoanAmount { get; set; }

    public string LoanType { get; set; } = null!;

    public DateTime? ApplicationDate { get; set; }

    public string? Status { get; set; }

    public int? AssignedOfficerId { get; set; }

    public string? Remarks { get; set; }

    public virtual Staff? AssignedOfficer { get; set; }

    public virtual ICollection<BackgroundVerification> BackgroundVerifications { get; set; } = new List<BackgroundVerification>();

    public virtual Customer Customer { get; set; } = null!;
}
