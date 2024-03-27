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
    internal class OrderImp : IOrder
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
                    ProductID = b.ProductID,
                    UserID = b.UserID,
                    Date = b.Date
                });
            return _orders;
        }

        public IEnumerable<OrderDTO> GetOrderUser(int idUser)
        {
            List<Models.Order> orders = webshopContext.Orders.Where(o=>o.UserID==idUser).ToList();
            List<OrderDTO> _orders =
            new(from b in orders
                select new OrderDTO()
                {
                    ID = b.ID,
                    ProductID = b.ProductID,
                    UserID = b.UserID,
                    Date = b.Date
                });
            return _orders;
        }

        public void MakeOrder(UserDTO user)
        {
            User userX = webshopContext.Users.Single(u => u.ID == user.ID);
            List<Models.BasketPosition> baskets = userX.BasketPositions.ToList();
            List<Models.Order> orders = webshopContext.Orders.ToList();
            List<Models.OrderPosition> orderPositions = webshopContext.OrderPositions.ToList();
            foreach (var item in baskets)
            {
                Models.Order newOrder =new Order() {
                UserID = user.ID,
                ProductID = item.ProductID,
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
    }
}
