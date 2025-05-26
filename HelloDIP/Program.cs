using HelloDIP.Core.Payment;
using HelloDIP.Core.Shopping;
using Microsoft.Extensions.DependencyInjection;

namespace HelloDIP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var paymentService = new PaymentService();
            var shoppingCart = new ShoppingCart(paymentService, new StoreSettings());
            shoppingCart.Checkout();

            ServiceProvider serviceProvider = RegisterTypesOnInitialAppStartup();


            // Dependencies verwenden
            // sog. Dependency Tree wird von alleine aufgeloest
            var transiantShoppingCart = serviceProvider.GetService<IShoppingCart>();
            transiantShoppingCart.Checkout();

            using (var scope = serviceProvider.CreateScope())
            {
                var transient1WithinScope = scope.ServiceProvider.GetService<IShoppingCart>();
                transient1WithinScope.Checkout();

                // Hat dieselbe PaymentService Instanz
                var transient2WithinScope = scope.ServiceProvider.GetService<IShoppingCart>();
                transient2WithinScope.Checkout();
            }
        }

        private static ServiceProvider RegisterTypesOnInitialAppStartup()
        {
            // Mit Dependency Injection Package
            var collection = new ServiceCollection();

            // 3 varianten Dependencies zu registrieren (Lebenszyklen für die Instanzen)

            // Jedes mal wird die Instanz neu erzeugt
            collection.AddTransient<IShoppingCart, ShoppingCart>();

            // Jedes Objekt wird innerhalb eines Scopes (ein Scope pro Request) nur einmal verwendet
            collection.AddScoped<IPaymentService, PaymentService>();

            // Ein Objekt wird nur ein einiziges Mal fuer die gesamte Lebenszeit der App erzeugt
            collection.AddSingleton<StoreSettings>();

            var serviceProvider = collection.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
