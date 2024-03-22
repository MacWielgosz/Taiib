using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    [ApiController]
    [Route("[controller]")]
    internal class BasketPositionController : ControllerBase
    {
        [HttpPost]
        public void PostBasketPosition(string name, double price, string image, bool isActive)
        {

        }
        [HttpDelete]
        public void DeleteBasketPosition()
        {

        }
        [HttpPut]
        public void PutBasketPostion()
        {

        }

        [HttpGet("{idUser}")]
        public IEnumerable<BasketPosition> GetBasketPostion(int idUser)
        {
            var products = from bp in DAL.WebshopContext.BasketPositions where bp.UserID == idUser
                           select new BasketPosition() 
                           {
                               ID = bp.ID,
                               ProductID = bp.ProductID,
                               UserID = bp.UserID,
                               Amount = bp.Amount
                           };

            return products;
        }
    }
}
