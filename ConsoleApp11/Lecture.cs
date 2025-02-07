using System;
using System.Collections.Generic;

namespace ConsoleApp11;

public partial class Lecture
{
    public int Id { get; set; }

    public string LectureRoom { get; set; } = null!;

    public int SubjectId { get; set; }

    public int TeacherId { get; set; }

    public virtual ICollection<GroupsLecture> GroupsLectures { get; set; } = new List<GroupsLecture>();

    public virtual Subject Subject { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
