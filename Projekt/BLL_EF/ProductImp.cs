using BLL;
using DAL;
using Microsoft.EntityFrameworkCore;

namespace BLL_EF
{
    public class ProductImp : IProduct
    {
        readonly WebshopContext webshopContext;

        public ProductImp(WebshopContext webshopContext)
        {
            this.webshopContext = webshopContext;
        }

        public void ActiveProduct(int id)
        {
            Models.Product product = webshopContext.Products.Single(p => p.ID == id);
            if(product.IsActive) {return; }
            product.IsActive = true;
            webshopContext.SaveChanges();
        }

        public void AddProduct(string name, double price, string image, bool isActive)
        {
            if (price<=0) return; 
            webshopContext.Products.Add(new Models.Product() { Name = name, Price = price, Image = image, IsActive = isActive });
            webshopContext.SaveChanges();

        }

        public void DeleteProduct(int id)
        {

            Models.Product product = webshopContext.Products.Single(p => p.ID == id);

            if (product.OrderPositions.Any()) product.IsActive = false;
            if (product.BasketPositions.Any()) return;

            webshopContext.Products.Remove(product);
        }

        public void EditProduct(int id, string name, double price, string image, bool isActive)
        {
            if (price <= 0) return;
            Models.Product product = webshopContext.Products.Single(p => p.ID == id);
            product.Name = name;
            product.Price = price;
            product.Image = image;
            product.IsActive = isActive;
            webshopContext.SaveChanges();
        }

        public IEnumerable<ProductDTO> GetProducts(int size, int from)
        {
            List<Models.Product> products1 = webshopContext.Products.ToList();
            List<ProductDTO> _products =
            new(from p in webshopContext.Products
                select new ProductDTO()
                {
                    ID = p.ID,
                    Name = p.Name,
                    Price = p.Price,
                    Image = p.Image,
                    IsActive = p.IsActive
                });
            return _products.GetRange(from,size);
        }

        public IEnumerable<ProductDTO> GetProductsByIsActive(bool isActive)
        {
            List<Models.Product> products = webshopContext.Products.Where(p => p.IsActive == isActive).ToList();
            List<ProductDTO> _products =
            new(from p in products
                select new ProductDTO()
                {
                    ID = p.ID,
                    Name = p.Name,
                    Price = p.Price,
                    Image = p.Image,
                    IsActive = p.IsActive
                });
            return _products;
        }

        public IEnumerable<ProductDTO> GetProductsByName(string name)
        {
            List<Models.Product> products = webshopContext.Products.Where(p => p.Name.Contains(name)).ToList();
            List<ProductDTO> _products =
            new(from p in products
                select new ProductDTO()
                {
                    ID = p.ID,
                    Name = p.Name,
                    Price = p.Price,
                    Image = p.Image,
                    IsActive = p.IsActive
                });
            return _products;
        }
    }
}
