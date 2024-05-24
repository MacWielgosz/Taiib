

namespace BLL
{

    public interface IProduct
    {
        //public IEnumerable<ProductDTO> GetProducts(int size, int from);
        //public IEnumerable<ProductDTO> GetProductsByName(string name);
        //public IEnumerable<ProductDTO> GetProductsByIsActive(bool isActive);
        //public IEnumerable<ProductDTO> GetProductsBySort(bool asc);

        public IEnumerable<ProductDTO> GetProducts(Sort sort);
        public ProductDTO GetProduct(int id);

        public void AddProduct(ProductRequestDTO productRequest);
        public void EditProduct(int id, ProductRequestDTO productRequest);
        public void DeleteProduct(int id);
        public void ActiveProduct(int id);
    }
}
