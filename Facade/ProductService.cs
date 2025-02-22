namespace Facade
{
    public class ProductService
    {   
        private int _quantity;
        public ProductService(int quantity)
        {
            _quantity = quantity;
        }
        public bool CheckStock(Product product)
        {
            Console.WriteLine($"Перевіряємо наявність товару '{product.Name}'...");
            return product.Quantity <= _quantity; 
        }
    }
}
