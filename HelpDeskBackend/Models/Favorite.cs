using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HelpDeskBackend.Models;

public partial class Favorite
{
    public int Id { get; set; }

    public int? TicketId { get; set; }

    public string? UserId { get; set; }

 
    public virtual Ticket? Ticket { get; set; }
}
