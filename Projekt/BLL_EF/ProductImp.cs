using BLL;
using DAL;

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
            product.IsActive = (!product.IsActive);
            webshopContext.SaveChanges();
        }

        public void AddProduct(ProductRequestDTO productRequest)
        {
            if (productRequest.Price <= 0) return; 
            webshopContext.Products.Add(new Models.Product() {
                Name = productRequest.Name, 
                Price = productRequest.Price, 
                Image = productRequest.Image, 
                IsActive = false
            });
            webshopContext.SaveChanges();

        }

        public void DeleteProduct(int id)
        {

            Models.Product product = webshopContext.Products.Single(p => p.ID == id);

            if (product.OrderPositions != null && product.OrderPositions.Any()) {
                return;
            };
            if (product.BasketPositions != null && product.OrderPositions.Any())  {
                product.IsActive = false;
                webshopContext.SaveChanges();
                return;
            }

            webshopContext.Products.Remove(product);
            webshopContext.SaveChanges();

        }

        public void EditProduct(int id, ProductRequestDTO productRequest)
        {
            if (productRequest.Price <= 0) return;
            Models.Product product = webshopContext.Products.Single(p => p.ID == id);
            product.Name = productRequest.Name;
            product.Price = productRequest.Price;
            product.Image = productRequest.Image;
            webshopContext.SaveChanges();
        }

        public ProductDTO GetProduct(int id)
        {
            Models.Product product = webshopContext.Products.Single(p => p.ID == id);

            ProductDTO productDTO = new()
            {
                ID = product.ID
                , Name = product.Name
                , Price = product.Price
                , Image = product.Image
                , IsActive = product.IsActive

            };

            return productDTO;
        }

        public IEnumerable<ProductDTO> GetProducts(Sort sort)
        {

            List<Models.Product> products1 = webshopContext.Products.ToList();
            List<ProductDTO> _products =
            new(from p in products1
                select new ProductDTO()
                {
                    ID = p.ID,
                    Name = p.Name,
                    Price = p.Price,
                    Image = p.Image,
                    IsActive = p.IsActive
                });
            
                _products = _products.Where(s => s.IsActive == sort.IsActive ).ToList();
            
            if (sort.Name != null)
                _products = _products.Where(s => s.Name.Contains(sort.Name)).ToList();
            
            if ((bool)!sort.Asc)
                _products = _products.OrderByDescending(s => s.Price).ToList();

            return _products.Skip((int)(sort.Size * sort.From)).Take((int)sort.Size);
        }
    }
}
