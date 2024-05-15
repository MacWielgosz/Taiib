using BLL;
using DAL;

namespace BLL_EF
{
    public class BasketPositionImp : IBasketPosition
    {
        readonly WebshopContext webshopContext;

        public BasketPositionImp(WebshopContext webshopContext)
        {
            this.webshopContext = webshopContext;
        }

        public void AddBasketPosition(BasketPositionRequestDTO basketPositionRequest)
        {   
            Models.BasketPosition basketPosition = new()
            {
                ProductID = basketPositionRequest.ProductID,
                UserID = basketPositionRequest.ProductID,
                Amount = basketPositionRequest.Amount
            };
            webshopContext.BasketPositions.Add(basketPosition);
            webshopContext.SaveChanges();
        }

        public void DeleteBasketPosition(int id)
        {
            Models.BasketPosition basket = webshopContext.BasketPositions.Single(b => b.ID == id);
            webshopContext.BasketPositions.Remove(basket);
            webshopContext.SaveChanges();
        }

        public void EditBasketPostion(int id, int amount)
        {
            if (amount <= 0) return;
            Models.BasketPosition basket = webshopContext.BasketPositions.Single(b => b.ID == id);
            basket.Amount = amount;
            webshopContext.SaveChanges();
        }

        public IEnumerable<BasketPositionDTO> GetBasketPostion(int userID)
        {
            List<Models.BasketPosition> baskets = webshopContext.BasketPositions.Where(b => b.UserID== userID).ToList();
            List<BasketPositionDTO> _baskets =
            new(from b in baskets
                select new BasketPositionDTO()
                {
                    ID = b.ID,
                    ProductID = b.ProductID,
                    UserID = userID,
                    Amount = b.Amount,
                });
            return _baskets;
        }
    }
}
