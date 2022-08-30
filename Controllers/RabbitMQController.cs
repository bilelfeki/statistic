using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using statistique.Models;
using statistique.Services.RabbitMQ;

namespace statistique.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitMQController : ControllerBase
    {

        [HttpPost]
        public string sendNotification([FromBody] Notification notification)
        {
            var rabbit = new Send();
            rabbit.Connection(notification);
            return "value";
        }
    }
}
