using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApiTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QnAController : ControllerBase
    {

        private readonly ILogger<QnAController> _logger;

        public QnAController(ILogger<QnAController> logger)
        {
            _logger = logger;
        }


    }
}
