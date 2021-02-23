using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiTask.Repository.IRepository;

namespace WebApiTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {

        private IUnitOfWork unitOfWork;

        public TagsController(IUnitOfWork unit)
        {
            unitOfWork = unit;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
              var result=  unitOfWork.Tags.GetAll();
            return Ok(result);
        }
    }
}
