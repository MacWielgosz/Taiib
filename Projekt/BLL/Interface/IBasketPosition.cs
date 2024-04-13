
namespace BLL
{
    public interface IBasketPosition { 
        public void AddBasketPosition(int productID, int userID, int amount);
        public void DeleteBasketPosition(int id);
        public void EditBasketPostion(int id,int amount);
        public IEnumerable<BasketPositionDTO> GetBasketPostion(int userID);
    }
}
