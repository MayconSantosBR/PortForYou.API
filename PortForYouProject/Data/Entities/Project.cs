using System;
using System.Collections.Generic;

namespace PortForYouProject.Data.Entities;

public partial class Project
{
    public int IdProject { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string Manager { get; set; } = null!;

    public int Status { get; set; } = 0!;

    public int Risk { get; set; } = 0!;

    public DateTime? StartDate { get; set; }

    public DateTime EstimatedDate { get; set; }

    public DateTime? FinishDate { get; set; }

    public double? TotalBudget { get; set; }

    public virtual ICollection<Functionary> IdFunctionaries { get; } = new List<Functionary>();
}
