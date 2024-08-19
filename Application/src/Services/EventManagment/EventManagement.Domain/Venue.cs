namespace EventManagement.Domain;

public class Venue
{
    public int VenueId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public DateTime InsertionTimestamp { get; set; } = DateTime.Now;    

}
