using BLL;
using Microsoft.AspNetCore.Mvc;
using BLL_EF;
using Models;

namespace WebAPI.Controllers
{
    public class OrderController : ControllerBase
    {
        private readonly IOrder iOrder;

        public OrderController(OrderImp order)
        {
            IOrder iOrder = order;
        }
        [HttpGet("makeOrder:{userID}")]
        public void MakeOrder(int userID) {
            iOrder.MakeOrder(userID);
        }
        [HttpGet]
        public IEnumerable<OrderDTO> GetOrderAll() {
            return iOrder.GetOrderAll();
        }
        [HttpGet("getOrder:{userID}")]
        public IEnumerable<OrderDTO> GetOrderUser(int userID) {
            return iOrder.GetOrderUser(userID);
        }

        [HttpGet("oders:{orderId}")]
        public IEnumerable<OrderPositionDTO> GetProductsByIsActive(int orderId)
        {
            return iOrder.OrderPosition(orderId);

        }

    }
}
