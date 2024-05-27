using BLL;
using DAL;
using Microsoft.EntityFrameworkCore;
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
            List<Models.Order> orders = webshopContext.Orders.Where(o=>o.UserID == userID).ToList();
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
            User userX = webshopContext.Users
                                        .Include(u => u.BasketPositions)
                                        .ThenInclude(bp => bp.Product)
                                        .SingleOrDefault(u => u.ID == userID);
            Console.WriteLine(userID); 
            if (userX == null)
            {
                throw new ArgumentException("Użytkownik o podanym ID nie istnieje");
            }

            List<BasketPosition> baskets = userX.BasketPositions.ToList();
            if (baskets == null || baskets.Count == 0)
            {
                throw new InvalidOperationException("Koszyk użytkownika jest pusty.");
            }
            Order newOrder = new Order
            {
                UserID = userX.ID,
                Date = DateTime.Now
            };
            webshopContext.Orders.Add(newOrder);
            webshopContext.SaveChanges();  // Zapisz nowy order, aby uzyskać jego ID

            foreach (var item in baskets)
            {
                if (item.Product == null)
                {
                    throw new InvalidOperationException($"Produkt z ID {item.ProductID} nie istnieje.");
                }
                
                OrderPosition orderPosition = new OrderPosition
                {
                    OrderID = newOrder.ID,
                    ProductID = item.ProductID,
                    Amount = item.Amount,
                    Price = item.Product.Price
                };
                webshopContext.OrderPositions.Add(orderPosition);

                webshopContext.BasketPositions.Remove(item);
            }

            webshopContext.SaveChanges();
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
