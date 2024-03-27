using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_EF
{
    internal class OrderPositionImp : IOrderPosition
    {
        readonly WebshopContext webshopContext;

        public OrderPositionImp(WebshopContext webshopContext)
        {
            this.webshopContext = webshopContext;
        }

        OrderPositionDTO IOrderPosition.OrderPosition(OrderDTO order)
        {
            Models.OrderPosition basket = webshopContext.OrderPositions.Single(b => b.OrderID == order.ID);

            return new OrderPositionDTO {
                ID=basket.ID,
                OrderID=basket.OrderID,
                Price= basket.Price,
                ProductID =basket.ProductID,
                Amount=basket.Amount
            };
        }
    }
}
