using BLL;
using BLL_EF;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class ProductController(ProductImp product) : ControllerBase
    {
        private readonly IProduct product = product;

        [HttpGet("product")]
        public IEnumerable<ProductDTO> GetProducts([FromQuery] Sort sort)
        {
            return product.GetProducts(sort);
        }
        [HttpGet("product/{id}")]
        public ProductDTO GetProducts(int id)
        {
            return product.GetProduct(id);
        }

        [HttpPost]
        public void AddProduct([FromBody]ProductRequestDTO productRequest)
        {
            product.AddProduct(productRequest);
        }
        [HttpPut("productEdit/{id}")]
        public void EditProduct(int id, [FromBody] ProductRequestDTO productRequest)
        {
            product.EditProduct(id, productRequest);
        }
        [HttpDelete("productDelete/{id}")]
        public void DeleteProduct(int id)
        {
            product.DeleteProduct(id);
        }
        [HttpPut("producPut/{id}")]
        public void ActiveProduct(int id)
        {
            product.ActiveProduct(id);
        }
    }
}
