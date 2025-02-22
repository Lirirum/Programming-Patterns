using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class Customer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double Balance { get; set; }

        public Customer(string name, string address, double balance)
        {
            Name = name;
            Address = address;
            Balance = balance;
        }
    }

    public class Product 
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }


        public Product(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
        public double GetAmount()
        {
            return Price * Quantity;
        }
    }
}
