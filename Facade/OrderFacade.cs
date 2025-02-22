using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class OrderFacade
    {
        private ProductService _productService;
        private PaymentService _paymentService;
        private ShippingService _shippingService;

        public OrderFacade(int quantity)
        {
            _productService = new ProductService(quantity);
            _paymentService = new PaymentService();
            _shippingService = new ShippingService();
        }

        public void PlaceOrder(Customer customer, Product product)
        {
            Console.WriteLine("\n--- Оформлення замовлення ---");

            if (!_productService.CheckStock(product))
            {
                Console.WriteLine("❌ Товару недостатньо на складі.");
                return;
            }

            if (!_paymentService.ProcessPayment(customer, product))
            {
                Console.WriteLine("❌ Платіж відхилено.");
                return;
            }

            _shippingService.ShipOrder(product, customer);
            Console.WriteLine("✅ Замовлення успішно оформлене!");
        }
    }
}
