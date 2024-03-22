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
    internal class OrderPositionController : ControllerBase
    {
        [HttpGet("{id}")]
        public OrderPosition GetOrder(int id)
        {

        }
    }
}
