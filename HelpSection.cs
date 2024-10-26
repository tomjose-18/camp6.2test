using System;
using System.Collections.Generic;

namespace Camp6_Final_Angular.Models;

public partial class HelpSection
{
    public int HelpId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;
}
