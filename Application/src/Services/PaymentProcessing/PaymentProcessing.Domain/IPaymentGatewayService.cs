using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessing.Domain
{
    public interface IPaymentGatewayService
    {
        Task<int> ProcessPaymentAsync(decimal amount, string currency, string paymentMethod);
        Task<bool> ProcessRefundAsync(Guid paymentId, decimal amount);
    }
}
