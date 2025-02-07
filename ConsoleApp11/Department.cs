using System;
using System.Collections.Generic;

namespace ConsoleApp11;

public partial class Department
{
    public int Id { get; set; }

    public decimal Financing { get; set; }

    public string Name { get; set; } = null!;

    public int FacultyId { get; set; }

    public virtual Faculty Faculty { get; set; } = null!;

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
}
