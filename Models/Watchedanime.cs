using System;
using System.Collections.Generic;

namespace coursach;

public partial class Watchedanime
{
    public int Id { get; set; }

    public int Userid { get; set; }

    public int Animeid { get; set; }

    public virtual User User { get; set; } = null!;
}
