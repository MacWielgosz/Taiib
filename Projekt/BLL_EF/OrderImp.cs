using BLL;
using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_EF
{
    public class OrderImp : IOrder
    {
        readonly WebshopContext webshopContext;

        public OrderImp(WebshopContext webshopContext)
        {
            this.webshopContext = webshopContext;
        }
        public IEnumerable<OrderDTO> GetOrderAll()
        {
            List<Models.Order> orders = webshopContext.Orders.ToList();
            List<OrderDTO> _orders =
            new(from b in orders
                select new OrderDTO()
                {
                    ID = b.ID,
                    UserID = b.UserID,
                    Date = b.Date
                });
            return _orders;
        }

        public IEnumerable<OrderDTO> GetOrderUser(int userID)
        {
            List<Models.Order> orders = webshopContext.Orders.Where(o=>o.UserID== userID).ToList();
            List<OrderDTO> _orders =
            new(from b in orders
                select new OrderDTO()
                {
                    ID = b.ID,
                    UserID = b.UserID,
                    Date = b.Date
                });
            return _orders;
        }

        public void MakeOrder(int userID)
        {
            User userX = webshopContext.Users.Single(u => u.ID == userID);
            List<Models.BasketPosition> baskets = userX.BasketPositions.ToList();
            List<Models.Order> orders = webshopContext.Orders.ToList();
            List<Models.OrderPosition> orderPositions = webshopContext.OrderPositions.ToList();
            foreach (var item in baskets)
            {
                Models.Order newOrder =new() {
                    UserID = userX.ID,
                    Date = DateTime.Today
                };
                orders.Add(newOrder);
                webshopContext.SaveChanges();
                    orderPositions.Add(new() {
                    OrderID = newOrder.ID,
                    ProductID=item.ProductID,
                    Amount = item.Amount,
                    Price = item.Product.Price
                });
                baskets.Remove(item);
                webshopContext.SaveChanges();
            }
        }
        public IEnumerable<OrderPositionDTO> OrderPosition(int orderID)
        {
            List<Models.OrderPosition> orderPositions = webshopContext.OrderPositions.Where( s => s.OrderID == orderID).ToList();
            List<OrderPositionDTO> orderPositionsDto =
            new(from b in orderPositions
                select new OrderPositionDTO()
                {
                    Amount = b.Amount,
                    Price = b.Price,
                    OrderID = orderID,
                    ID = orderID,
                    ProductID = b.ProductID
                                        
                });
            return orderPositionsDto;
        }
    }
}
