namespace EventManagement.Domain;

public class Seat
{
    public int SeatId { get; set; }
    public int VenueId { get; set; }
    public string SeatNumber { get; set; }
    public string RowNumber { get; set; }
    public string Enclosure { get; set; }  // vip, economy , executive etc
    public string Status { get; set; } // active , deleted ,booked
    public DateTime InsertionTimestamp { get; set; } = DateTime.Now;
    public DateTime UserId { get; set; } // created by user

}
