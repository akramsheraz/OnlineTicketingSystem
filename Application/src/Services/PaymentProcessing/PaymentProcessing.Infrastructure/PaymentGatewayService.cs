using PaymentProcessing.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessing.Infrastructure
{
    public class PayPalPaymentGatewayService : IPaymentGatewayService
    {
        public async Task<int> ProcessPaymentAsync(decimal amount, string currency, string paymentMethod)
        {
            // Integrate with Payment gateway
            // Return the payment ID

            return await ProcessPaymentAsync(amount, currency, currency); 
        }

        public async Task<bool> ProcessRefundAsync(Guid paymentId, decimal amount)
        {
            // Integrate with PayPal for refund
            // Return the result of the refund operation
            return true;
        }
    }
}
