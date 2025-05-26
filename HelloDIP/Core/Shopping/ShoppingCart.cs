using HelloDIP.Core.Payment;

namespace HelloDIP.Core.Shopping;

public class ShoppingCart : IShoppingCart
{
    // Nicht gegen konkrete Implementierung sondern besser gegen Interface
    PaymentService paymentService_bad = new PaymentService();


    private readonly IPaymentService _paymentService;
    private readonly StoreSettings _storeSettings;

    public ShoppingCart(IPaymentService paymentService, StoreSettings storeSettings)
    {
        _paymentService = paymentService;
        _storeSettings = storeSettings;
    }

    public void Checkout()
    {
        Console.WriteLine($"\n\nStoreSettings: {_storeSettings.Foo}");
        _paymentService.MakePayment();
    }
}
