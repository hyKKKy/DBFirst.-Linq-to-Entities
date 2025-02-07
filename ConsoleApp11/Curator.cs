using System;
using System.Collections.Generic;

namespace ConsoleApp11;

public partial class Curator
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public virtual ICollection<GroupsCurator> GroupsCurators { get; set; } = new List<GroupsCurator>();
}
