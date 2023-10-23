using Application.Dtos;
using Domain;

namespace Application.Services.Interfaces
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product GetById(int id);
        bool Create(Product product);
        bool Update(Product product);
        bool Delete(int id);
    }
}
