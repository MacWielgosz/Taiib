
namespace BLL
{
    public interface IBasketPosition { 
        public void AddBasketPosition(ProductDTO product,UserDTO user, int amount);
        public void DeleteBasketPosition(int id);
        public void EditBasketPostion(int id,int amount);
        public IEnumerable<BasketPositionDTO> GetBasketPostion(UserDTO user);
    }
}
