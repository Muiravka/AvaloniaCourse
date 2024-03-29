﻿using System;
using System.Collections.Generic;

namespace coursach.Models;

public partial class Usercomment
{
    public int Id { get; set; }

    public int Userid { get; set; }

    public string Commentcontent { get; set; } = null!;

    public int? AnimeId { get; set; }

    public DateTime? Commentdate { get; set; }

    public virtual User User { get; set; } = null!;
}
