using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bot1;

namespace ToyRobot.API.Controllers
{
    [Route("[controller]")]
    [ApiController] //allows you to receive web request, identifies it specifically as a controller
    public class BotController : ControllerBase // need to always call it SOMETHINGController.
    {
        private readonly Bot _bot = new Bot();
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "text1", "value2" };
        }


        [HttpGet("report")]
        public ActionResult<string> Report()
        {
            return _bot.ReportText();
        }
    }
}
