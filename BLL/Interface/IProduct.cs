
namespace BLL
{
    public interface IProduct
    {
        public IEnumerable<ProductDTO> GetProducts(int size, int from);
        public IEnumerable<ProductDTO> GetProductsByName(string name);
        public IEnumerable<ProductDTO> GetProductsByIsActive(bool isActive);
        public void AddProduct(string name, double price, string image, bool isActive);
        public void EditProduct(int id, string name, double price, string image, bool isActive);
        public void DeleteProduct(int id);
        public void ActiveProduct(int id);
    }
}
