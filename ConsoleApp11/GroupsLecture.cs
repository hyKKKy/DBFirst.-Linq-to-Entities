﻿using System;
using System.Collections.Generic;

namespace ConsoleApp11;

public partial class GroupsLecture
{
    public int Id { get; set; }

    public int GroupId { get; set; }

    public int LectureId { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual Lecture Lecture { get; set; } = null!;
}
