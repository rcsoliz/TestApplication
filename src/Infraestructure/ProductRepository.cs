using Application.Repository;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }
        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetById(int id)
        {
            var product = _context.Products.SingleOrDefault(x => x.ProductId == id);
            return product!;
        }
        public bool Create(Product product)
        {
            product.ProductId = 0;
            _context.Products.Add(product);
            _context.SaveChanges();
            return true;
        }
        public bool Update(Product product)
        {
            var item = GetById(product.ProductId);
            if (item != null)
            {
                _context.Entry(item).CurrentValues.SetValues(product);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                _context.Products.Remove(item);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
