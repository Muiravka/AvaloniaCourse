using System;
using System.Collections.Generic;

namespace coursach.Models;

public partial class User
{
    public int Id { get; set; }

    public string Nickname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public virtual ICollection<Droppedanime> Droppedanimes { get; } = new List<Droppedanime>();

    public virtual ICollection<Plantowatch> Plantowatches { get; } = new List<Plantowatch>();

    public virtual ICollection<Usercomment> Usercomments { get; } = new List<Usercomment>();

    public virtual ICollection<Watchedanime> Watchedanimes { get; } = new List<Watchedanime>();
}
