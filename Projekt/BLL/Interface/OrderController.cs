using Microsoft.AspNetCore.Mvc;
using Models;

namespace BLL
{
    [ApiController]
    [Route("[controller]")]
    internal class OrderController : ControllerBase
    {
        [HttpPost]
        public void PostOrder()
        {

        }
        [HttpGet]
        public IEnumerable<Order> GetOrder()
        {

        }

        [HttpGet("{idUser}")]
        public IEnumerable<Order> GetOrder(int idUser)
        {

        }
    }
}
