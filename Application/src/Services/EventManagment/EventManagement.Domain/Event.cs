namespace EventManagement.Domain;

public class Event
{
    public int EventId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }    
    public DateTime Date { get; set; }
    public TimeSpan Time { get; set; } = TimeSpan.Zero;
    public int VenueId { get; set; }
    public string Status { get; set; } // active , deleted , pending, postponed
    public DateTime InsertionTimestamp { get; set; } = DateTime.Now;
    public int UserId { get; set; } // created by user
}
