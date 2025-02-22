using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class ShippingService
    {
        public void ShipOrder(Product product, Customer customer)
        {
            Console.WriteLine($"Доставка {product.Quantity} шт. товару '{product.Name}' за адресою: {customer.Address}.");
        }
    }
}
