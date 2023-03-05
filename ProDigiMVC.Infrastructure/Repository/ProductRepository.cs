using ProDigiMVC.Domain.Interfaces;
using ProDigiMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProDigiMVC.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context db;
        public ProductRepository(Context context)
        {
            db = context;
        }

        public void DeleteProduct(int productId)
        {
            var product = db.Products.Find(productId);
            if (product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
            }
        }

        public int AddProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return product.Id;
        }

        public IQueryable<Product> GetProductsByCustomerId(int customerId)
        {
            var items = db.Products.Where(x => x.CustomerId == customerId);
            return items;
        }

        public Product GetProductById(int productId)
        {
            var product = db.Products.FirstOrDefault(p => p.Id == productId);
            return product;
        }
    }
}
