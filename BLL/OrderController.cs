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
