using PaymentProcessing.Domain;
using PaymentProcessing.Domain;

namespace EventManagement.Infrastructure.Respositories;

public class PaymentRepository : IPaymentRepository
{
    
    public async Task<Payment> GetPaymentByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task AddPaymentAsync(Payment payment)
    {
        //await _context.Payments.AddAsync(payment);
        //await _context.SaveChangesAsync();
        throw new NotImplementedException();
    }

    public async Task UpdatePaymentAsync(Payment payment)
    {
        //_context.Payments.Update(payment);
        //await _context.SaveChangesAsync();
        throw new NotImplementedException();
    }
}


