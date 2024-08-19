namespace PaymentProcessing.Domain;

public class Payment
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; }
    public string PaymentMethod { get; set; }
    public DateTime CreatedAt { get; set; }

    // Other properties go here for profile
}
