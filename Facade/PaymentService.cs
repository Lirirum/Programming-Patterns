using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class PaymentService
    {
        

        public bool ProcessPayment(Customer customer, Product product)
        {
            Console.WriteLine($"Обробка платежу від {customer.Name} на суму {product.GetAmount()} грн...");
            return  product.GetAmount() < customer.Balance; // Умовна логіка
        }
    }
}
