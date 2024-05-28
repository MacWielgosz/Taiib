using BLL;
using Microsoft.AspNetCore.Mvc;
using BLL_EF;
using Models;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [ApiController,Authorize]
    public class OrderController(OrderImp order) : ControllerBase
    {
        private readonly IOrder iOrder = order;

        [HttpPost("makeOrder/{userID}")]
        public void MakeOrder(int userID) {
            iOrder.MakeOrder(userID);
        }
        [HttpGet("orderall")]
        [Authorize(Roles ="admin")]
        public IEnumerable<OrderDTO> GetOrderAll() {
            return iOrder.GetOrderAll();
        }
        [HttpGet("getOrder/{userID}")]
        public IEnumerable<OrderDTO> GetOrderUser(int userID) {
            return iOrder.GetOrderUser(userID);
        }

        [HttpGet("oders/{orderId}")]
        public IEnumerable<OrderPositionDTO> GetProductsByIsActive(int orderId)
        {
            return iOrder.OrderPosition(orderId);
        }

    }
}
