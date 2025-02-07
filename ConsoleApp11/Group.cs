using System;
using System.Collections.Generic;

namespace ConsoleApp11;

public partial class Group
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Year { get; set; }

    public int DepartamentId { get; set; }

    public virtual Department Departament { get; set; } = null!;

    public virtual ICollection<GroupsCurator> GroupsCurators { get; set; } = new List<GroupsCurator>();

    public virtual ICollection<GroupsLecture> GroupsLectures { get; set; } = new List<GroupsLecture>();
}
