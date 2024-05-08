﻿using BLL;
using BLL_EF;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class BasketPositionController : ControllerBase
    {
        private readonly IBasketPosition basketPosition;

        public BasketPositionController(BasketPositionImp basketPosition)
        {
            this.basketPosition = basketPosition;
        }
        [HttpPost]
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
