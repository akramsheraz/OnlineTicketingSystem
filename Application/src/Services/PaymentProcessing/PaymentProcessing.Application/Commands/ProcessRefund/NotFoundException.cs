
namespace PaymentProcessing.Application.Commands.ProcessRefund
{
    [Serializable]
    internal class NotFoundException : Exception
    {
        private string v;
        private Guid paymentId;

        public NotFoundException()
        {
        }

        public NotFoundException(string? message) : base(message)
        {
        }

        public NotFoundException(string v, Guid paymentId)
        {
            this.v = v;
            this.paymentId = paymentId;
        }

        public NotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}