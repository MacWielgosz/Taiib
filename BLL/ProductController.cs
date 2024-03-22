using Microsoft.AspNetCore.Mvc;
using Models;

namespace BLL
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Product> GetProducts() {

            var products = from p in DAL.WebshopContext.Products
                           select new Product()
                           {
                               ID = p.ID,
                               Name = p.Name,
                               Price = p.Price,
                               Image = p.Image,
                               IsActive = p.IsActive,
                           };
            return products;
        }
        [HttpGet("{name}")]
        public IEnumerable<Product> GetProducts(string name)
        {
            var products = from p in DAL.WebshopContext.Products where p.Name == name
                           select new Product()
                           {
                               ID = p.ID,
                               Name = p.Name,
                               Price = p.Price,
                               Image = p.Image,
                               IsActive = p.IsActive,
                           };
            return products;
        }
        [HttpGet("{isActive}")]
        public IEnumerable<Product> GetProducts(bool isActive)
        {
            var products = from p in DAL.WebshopContext.Products
                           where p.IsActive == isActive
                           select new Product()
                           {
                               ID = p.ID,
                               Name= p.Name ,
                               Price = p.Price,
                               Image = p.Image,
                               IsActive = p.IsActive,
                           };
            return products;
        }
        [HttpPost]
        public void PostProduct(string name,double price, string image, bool isActive  )
        {
            DAL.WebshopContext.Products.Add(new Product() {Name=name,Price=price,Image=image,IsActive = isActive });
        }
        [HttpPut]
        public void EditProduct(int id)
        {
        
        }

        [HttpDelete]
        public void DeleteProduct(int id)
        {

        }

        [HttpPut]
        public void ActiveProduct(int id)
        {

        }
    }
}
