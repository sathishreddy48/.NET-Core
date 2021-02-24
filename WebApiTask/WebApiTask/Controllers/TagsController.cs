using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiTask.Repository.IRepository;
using WebApiTask.Models;
using System.Net;

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
        public async Task<IEnumerable<Tags>> GetAllAsync()
        {
            var result= await unitOfWork.Tags.GetAllAsync();
            return result;
        }

        [HttpPost]
        [Route("AddTags")]
        public async Task AddTagsAsync([FromBody] Tags tags)
        {
            try
            {
                if (tags.Id == Guid.Empty)
                {
                    tags.Id = Guid.NewGuid();
                    await unitOfWork.Tags.AddAsync(tags);
                }
                else
                {
                    await unitOfWork.Tags.UpdateTagAsync(tags);
                }

                unitOfWork.Save();
            }
            catch(Exception ex)
            {
                this.HttpContext.Response.ContentType = "text/plain";
                this.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await this.HttpContext.Response.WriteAsync("An error occurred while creating Tags AddTagsAsync API\n" + ex.Message);
            }
        }
    }
}
