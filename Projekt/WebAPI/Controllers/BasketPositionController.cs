using BLL;
using BLL_EF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [ApiController]
    public class BasketPositionController : ControllerBase
    {
        private readonly IBasketPosition _basketPosition;

        public BasketPositionController(BasketPositionImp basketPosition)
        {
            _basketPosition = basketPosition;
        }
        [Authorize]
        [HttpPost("/basketPosition")]
        public void AddBasketPosition([FromBody] BasketPositionRequestDTO basketPositionRequestDTO)
        {
            _basketPosition.AddBasketPosition(basketPositionRequestDTO);
        }
        [Authorize]
        [HttpDelete("/basketPosition/{id}")]
        public void DeleteBasketPosition(int id)
        {
            _basketPosition.DeleteBasketPosition(id);
        }
        [Authorize]
        [HttpPut("/basketPosition/{id},{amount}")]
        public void EditBasketPostion(int id, int amount)
        {
            _basketPosition.EditBasketPostion(id, amount);
        }
        [Authorize]
        [HttpGet("/basketPosition/{userID}")]
        public IEnumerable<BasketPositionDTO> GetBasketPostion(int userID)
        {
            return _basketPosition.GetBasketPostion(userID);
        }
    }
}
