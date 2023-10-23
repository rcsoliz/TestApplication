using Application.Dtos;
using Application.Repository;
using Application.Services.Interfaces;
using AutoMapper;
using Domain;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
      //  private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
         //   _mapper = mapper;
        }
        public List<Product> GetAll()
        {
            var list = _productRepository.GetAll();
            return list;
        }
        public Product GetById(int id)
        {
            var item = _productRepository.GetById(id);
            return item;
        }

        public bool Create(Product product)
        {
          //  var item = _mapper.Map<Product>(product);
            var addItem = _productRepository.Create(product);
            return addItem;
        }
        public bool Update(Product product)
        {
            //var item = _mapper.Map<Product>(product);
            var updateItem= _productRepository.Update(product);
            return updateItem;
        }
        public bool Delete(int id)
        {
            var isRemove = _productRepository.Delete(id);
            return isRemove;
        }

    }
}
