namespace EventManagement.Domain;

public class Tickets
{
    public int TicketId { get; set; }
    public int EventId { get; set; }    
    public decimal Price { get; set; }
    public int SeatId { get; set; }    
}
