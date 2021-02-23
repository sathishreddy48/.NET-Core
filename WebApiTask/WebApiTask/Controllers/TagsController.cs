using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiTask.Repository.IRepository;
using WebApiTask.Models;

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
        [Route("GetTags")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result= await unitOfWork.Tags.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        [Route("AddTags")]
        public async Task<IActionResult> AddTagsAsync([FromBody] Tags tags)
        {
           await unitOfWork.Tags.AddAsync(tags);
           unitOfWork.Save();
            return Ok();
        }
    }
}
