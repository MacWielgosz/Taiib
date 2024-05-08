using BLL;
using BLL_EF;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class OrderPositionController : ControllerBase
    {
        private readonly IOrderPosition orderPosition;

        public OrderPositionController(OrderPositionImp orderPosition)
        {
            this.orderPosition = orderPosition;
        }
        [HttpGet("{orderID}")]
        public OrderPositionDTO OrderPosition(int orderID)
        {
            return orderPosition.OrderPosition(orderID);
        }

    }
}
