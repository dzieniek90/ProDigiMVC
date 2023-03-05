using ProDigiMVC.Domain.Model;

namespace ProDigiMVC.Domain.Interfaces
{
    public interface IProductRepository
    {
        int AddProduct(Product product);
        void DeleteProduct(int productId);
        Product GetProductById(int productId);
        IQueryable<Product> GetProductsByCustomerId(int customerId);
    }
}