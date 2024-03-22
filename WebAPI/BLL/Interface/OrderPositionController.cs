using Microsoft.AspNetCore.Mvc;
using Models;

namespace BLL
{
    [ApiController]
    [Route("[controller]")]
    internal class OrderPositionController : ControllerBase
    {
        [HttpGet("{id}")]
        public OrderPosition OrderPosition(int id)
        {

        }
    }
}
