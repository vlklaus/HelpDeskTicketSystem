using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HelpDeskBackend.Models;

public partial class Ticket
{
    public int Id { get; set; }

    public string? User { get; set; }

    public string? Problem { get; set; }

    public string? Resolution { get; set; }

    public bool? Completed { get; set; }

    [JsonIgnore]
    public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
}
