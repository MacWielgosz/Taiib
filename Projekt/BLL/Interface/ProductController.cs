using Microsoft.AspNetCore.Mvc;

namespace BLL
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private static List<ProductDTO> _products =
            new(from p in DAL.WebshopContext.Products
                select new ProductDTO()
                {
                    ID = p.ID,
                    Name = p.Name,
                    Price = p.Price,
                    Image = p.Image,
                    IsActive = p.IsActive
                });


        [HttpGet("{size},{from}")]
        public IEnumerable<ProductDTO> GetProducts(int size, int from)
        {

            return _products.GetRange(from, size);
        }
        [HttpGet("{name}")]
        public ProductDTO GetProducts(string name)
        {
            return _products.SingleOrDefault(p => p.Name == name);
        }
        [HttpGet("{isActive}")]
        public IEnumerable<ProductDTO> GetProducts(bool isActive)
        {
            return _products.Where(p => p.IsActive == isActive);
        }
        [HttpPost]
        public void PostProduct(string name, double price, string image, bool isActive)
        {
            _products.Add(new ProductDTO() { Name = name, Price = price, Image = image, IsActive = isActive });
        }
        [HttpPut("{id}")]
        public void EditProduct(int id)
        {

        }

        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {

        }

        [HttpPut("{id}")]
        public void ActiveProduct(int id)
        {

        }
    }
}
