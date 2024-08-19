using System.ComponentModel.DataAnnotations;

namespace TicketsManagement.Domain;

public class BookingData
{
    [Key]
    public int BookingId { get; set; }
    public int EventId { get; set; }
    public int SeatId { get; set; }
    public int TicketId { get; set; }
    public int UserId { get; set; }    
    public int VenueId { get; set; }
    public decimal Amount { get; set; }
    public string PaymentMethod { get; set; }
    public string PaymentStatus { get; set; }
    public DateTime InsertionTimestamp { get; set; } = DateTime.Now;
}
