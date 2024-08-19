using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessing.Domain
{
    public interface IPaymentGatewayFactory
    {
        IPaymentGatewayService Create(PaymentGatewayType gatewayType);
    }
}
