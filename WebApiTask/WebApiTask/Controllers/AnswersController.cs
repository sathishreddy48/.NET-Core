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
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await unitOfWork.Answers.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                this.HttpContext.Response.ContentType = "text/plain";
                this.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await this.HttpContext.Response.WriteAsync("An error occurred while fetching questions GetAllAsync API\n" + ex.Message);
                return NoContent();
            }
        }

        [HttpPost]
        [Route("AddAnswers")]
        public async Task AddAnswersAsync([FromBody] Answers answer)
        {
            try
            {
                if (answer.Id == Guid.Empty)
                {
                    answer.Id = Guid.NewGuid();
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

        [HttpGet]
        [Route("GetAnswersByQuestion/{question}")]
        public async Task<IActionResult> GetAnswersByquestionAsync(string question)
        {
            IEnumerable<Answers> answers = null;
            if (string.IsNullOrEmpty(question))
            {
                this.HttpContext.Response.ContentType = "text/plain";
                this.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await this.HttpContext.Response.WriteAsync($"Parameter {nameof(question)} cannot be null or empty.");
            }
            try
            {
                var qobjs = await unitOfWork.Questions.GetAllAsync();
                var q= qobjs.Where(q => q.Question.Equals(question)).FirstOrDefault();
                if (q == null)
                {
                    this.HttpContext.Response.ContentType = "text/plain";
                    this.HttpContext.Response.StatusCode = (int)HttpStatusCode.NoContent;
                    await this.HttpContext.Response.WriteAsync($"question {question} not found ");
                }
                answers= unitOfWork.Answers.GetAllAsync().GetAwaiter().GetResult()?.Where(x => x.QuestionID == q.Id).ToList();

            }
            catch (Exception ex)
            {
                this.HttpContext.Response.ContentType = "text/plain";
                this.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await this.HttpContext.Response.WriteAsync("An error occurred while fetch questions GetQuestionsByTags API\n" + ex.Message);
            }
            return Ok(answers);
        }

    }
}
