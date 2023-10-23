using Domain;

namespace Application.Repository
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product GetById(int id);
        bool Create(Product product);
        bool Update(Product product);
        bool Delete(int id);


    }
}
