using Application.Services.Interfaces;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _product;

        public ProductController(IProductService productRepository)
        {
            _product = productRepository;
        }


        [HttpGet("ListProducts")]
        public IEnumerable<Product> ListProducts()
        {
            return _product.GetAll();
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var item = _product.GetById(id);
            return item != null ? Ok(item) as IActionResult : NotFound();
        }

        [HttpPost("Save")]
        public IActionResult Create(Product product)
        {
            var result = _product.Create(product);

            if (result)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();


            }
        }

        [HttpPut("Update")]
        public IActionResult Update(Product product)
        {
            var result = _product.Update(product);

            if (result)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();


            }
        }

        [HttpPut("Remove/{id:int}")]
        public IActionResult Remove(int id)
        {
            var result = _product.Delete(id);

            if (result)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();


            }
        }



    }

}
