using System;
using System.Collections.Generic;

namespace ConsoleApp11;

public partial class Faculty
{
    public int Id { get; set; }

    public decimal Financing { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
}
