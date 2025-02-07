using System;
using System.Collections.Generic;

namespace ConsoleApp11;

public partial class Teacher
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Salary { get; set; }

    public string Surname { get; set; } = null!;

    public virtual ICollection<Lecture> Lectures { get; set; } = new List<Lecture>();
}
