using System;
using System.Collections.Generic;

namespace coursach.Models;

public partial class UserComment
{
    public int Id { get; set; }

    public int Userid { get; set; }

    public string Commentcontent { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
