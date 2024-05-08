using BLL;
using BLL_EF;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly IProduct product;

        public ProductController(ProductImp product)
        {
            this.product = product;
        }
        [HttpGet("{size},{from}")]
        public IEnumerable<ProductDTO> GetProducts(int size, int from)
        {
            return product.GetProducts(size,from);
        }
        [HttpGet("{name}")]
        public IEnumerable<ProductDTO> GetProductsByName(string name)
        {
            return product.GetProductsByName(name);
        }
        [HttpGet("{isActive}")]
        public IEnumerable<ProductDTO> GetProductsByIsActive(bool isActive)
        {
            return product.GetProductsByIsActive(isActive);

        }
        [HttpPost]
        public void AddProduct([FromBody]ProductRequestDTO productRequest)
        {
            product.AddProduct(productRequest);
        }
        [HttpPut("{id}")]
        public void EditProduct(int id, [FromBody] ProductRequestDTO productRequest)
        {
            product.EditProduct(id, productRequest);
        }
        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
            product.DeleteProduct(id);
        }
        [HttpPut("{id}")]
        public void ActiveProduct(int id)
        {
            product.ActiveProduct(id);
        }
    }
}
