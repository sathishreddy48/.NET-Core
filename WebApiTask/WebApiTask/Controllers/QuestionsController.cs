using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiTask.Models;
using WebApiTask.Repository.IRepository;
using WebApiTask.Utils;

namespace WebApiTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private IUnitOfWork unitOfWork;

        public QuestionsController(IUnitOfWork unit)
        {
            unitOfWork = unit;
        }

        [HttpGet]
        [Route("GetQuestions")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await unitOfWork.Questions.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        [Route("AddQuestions")]
        public async Task AddQuestionsAsync([FromBody] Questions question)
        {
            try
            {
                if (question.Id == Guid.Empty)
                {
                    question.Id = Guid.NewGuid();
                    await unitOfWork.Questions.AddAsync(question);
                }
                else
                {
                    await unitOfWork.Questions.UpdateQuestionsAsync(question);
                }
                unitOfWork.Save();
            }
            catch (Exception ex)
            {
                this.HttpContext.Response.ContentType = "text/plain";
                this.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await this.HttpContext.Response.WriteAsync("An error occurred while creating questions AddQuestionsAsync API\n" + ex.Message);
            }
        }


        [HttpGet]
        [Route("GetQuestionsByTags/{tags}")]
        public async Task<IActionResult> GetQuestionsByTags(string tags)
        {
            IEnumerable<Questions> questions = null;
            try
            {
               var que = await unitOfWork.Questions.GetAllAsync();
               questions =que.Where(x => x.Tags.Contains(tags)).ToList();

            }
            catch (Exception ex)
            {
                this.HttpContext.Response.ContentType = "text/plain";
                this.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await this.HttpContext.Response.WriteAsync("An error occurred while fetch questions GetQuestionsByTags API\n" + ex.Message);
            }
            return Ok(questions);
        }
    }
}
