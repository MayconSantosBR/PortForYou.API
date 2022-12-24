using System;
using System.Collections.Generic;

namespace PortForYouProject.Data.Entities;

public partial class Functionary
{
    public int IdFunctionary { get; set; }

    public string Name { get; set; } = null!;

    public string Ocuppation { get; set; } = null!;

    public virtual ICollection<Project> IdProjects { get; } = new List<Project>();
}
