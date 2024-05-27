using BLL;
using BLL_EF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    public class BasketPositionController(BasketPositionImp basketPosition) : ControllerBase
    {
        private readonly IBasketPosition basketPosition = basketPosition;

        [HttpPost("basketPosition")]
        public void AddBasketPosition([FromBody]BasketPositionRequestDTO basketPositionRequestDTO)
        {
            basketPosition.AddBasketPosition(basketPositionRequestDTO);
        }
        [HttpDelete("basketPosition/{id}")]
        public void DeleteBasketPosition(int id)
        {
            basketPosition.DeleteBasketPosition(id);
        }
        [HttpPut("basketPosition/{id}, {amount}")]
        public void EditBasketPostion(int id, int amount)
        {
            basketPosition.EditBasketPostion(id, amount);
        }

        [HttpGet("basketPosition/{userID}")]
        public IEnumerable<BasketPositionDTO> GetBasketPostion(int userID)
        {
            return basketPosition.GetBasketPostion(userID);
        }

    }
}
