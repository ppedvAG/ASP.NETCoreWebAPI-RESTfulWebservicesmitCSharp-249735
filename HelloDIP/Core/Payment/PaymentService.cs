using HelloDIP.Core.Shopping;

namespace HelloDIP.Core.Payment;

public class PaymentService : IPaymentService
{
    public void MakePayment()
    {
        Console.WriteLine($"Payment made [{GetHashCode()}]");
    }
}
