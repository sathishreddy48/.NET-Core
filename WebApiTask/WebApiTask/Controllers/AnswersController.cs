using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiTask.Models;
using WebApiTask.Repository.IRepository;

namespace WebApiTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private IUnitOfWork unitOfWork;

        public AnswersController(IUnitOfWork unit)
        {
            unitOfWork = unit;
        }

        [HttpGet]
        [Route("GetAnswers")]
        public async Task<IEnumerable<Answers>> GetAllAsync()
        {
            var result = await unitOfWork.Answers.GetAllAsync();
            return result;
        }

        [HttpPost]
        [Route("AddAnswers")]
        public async Task AddAnswersAsync([FromBody] Answers answer)
        {
            try
            {
                if (answer.Id == null)
                {
                    await unitOfWork.Answers.AddAsync(answer);
                }
                else
                {
                    await unitOfWork.Answers.UpdateAnswersAsync(answer);
                }

                unitOfWork.Save();
            }
            catch (Exception ex)
            {
                this.HttpContext.Response.ContentType = "text/plain";
                this.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await this.HttpContext.Response.WriteAsync("An error occurred while creating answer AddAnswersAsync API\n" + ex.Message);
            }
        }

    }
}
