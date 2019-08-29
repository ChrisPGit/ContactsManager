using Microsoft.AspNetCore.Mvc;
using System;

namespace ContactsManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadyController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            return $"The API is ready. {DateTime.Now.ToLongDateString()} à {DateTime.Now.ToLongTimeString()}";
        }
    }
}
