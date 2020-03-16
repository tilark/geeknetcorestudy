using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RoutingDemo.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    //[Route("api/[controller]/[action]")]
    [ApiController]
   
    public class OrderController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       [HttpGet("{id:MyRouteConstraint}")]
       public bool OrderExist(object id)
        {
            return true;
        }
    }
}
