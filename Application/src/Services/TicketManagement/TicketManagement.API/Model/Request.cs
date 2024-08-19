namespace TicketManagement.API.Model
{
    public class BookingRequest
    {  
        public int EventId { get; set; }
        public int SeatId { get; set; }
        public int TicketId { get; set; }
        public int UserId { get; set; }     
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }        
    }

    public class PaymentRequest
    {
        public int PaymentInstrumentType { get; set; }
        public int CreditCardNo { get; set; }
    }


}
