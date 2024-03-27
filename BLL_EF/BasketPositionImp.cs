using BLL;
using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BLL_EF
{
    internal class BasketPositionImp : IBasketPosition
    {
        readonly WebshopContext webshopContext;

        public BasketPositionImp(WebshopContext webshopContext)
        {
            this.webshopContext = webshopContext;
        }

        public void AddBasketPosition(ProductDTO product, UserDTO user, int amount)
        {
            Models.BasketPosition basketPosition = new()
            {
                ProductID = product.ID,
                UserID = user.ID,
                Amount = amount
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

        public IEnumerable<BasketPositionDTO> GetBasketPostion(UserDTO user)
        {
            List<Models.BasketPosition> baskets = webshopContext.BasketPositions.Where(b => b.UserID==user.ID ).ToList();
            List<BasketPositionDTO> _baskets =
            new(from b in baskets
                select new BasketPositionDTO()
                {
                    ID = b.ID,
                    ProductID = b.ProductID,
                    UserID = user.ID,
                    Amount = b.Amount,
                });
            return _baskets;
        }
    }
}
