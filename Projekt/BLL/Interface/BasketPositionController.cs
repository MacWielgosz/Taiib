using Microsoft.AspNetCore.Mvc;
using Models;

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
        [HttpDelete("{id}")]
        public void DeleteBasketPosition(int id)
        {

        }
        [HttpPut("{id}")]
        public void PutBasketPostion(int id)
        {

        }

        [HttpGet("{idUser}")]
        public IEnumerable<BasketPosition> GetBasketPostion(int idUser)
        {
            
        }
    }
}
