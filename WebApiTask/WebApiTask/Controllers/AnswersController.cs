// <copyright file="AnswersController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WebApiTask.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using WebApiTask.Models;
    using WebApiTask.Repository.IRepository;

    /// <summary>
    /// Controller to handle Answers API operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnswersController"/> class.
        /// </summary>
        /// <param name="unit">unit.</param>
        public AnswersController(IUnitOfWork unit)
        {
            this.unitOfWork = unit;
        }

        /// <summary>
        /// GetAllAsync answers.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpGet]
        [Route("GetAnswers")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await this.unitOfWork.Answers.GetAllAsync();
                return this.Ok(result);
            }
            catch (Exception ex)
            {
                this.HttpContext.Response.ContentType = "text/plain";
                this.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await this.HttpContext.Response.WriteAsync("An error occurred while fetching questions GetAllAsync API\n" + ex.Message);
                return this.NoContent();
            }
        }

        /// <summary>
        /// Add Answers Async.
        /// </summary>
        /// <param name="answer">answer object.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [HttpPost]
        [Route("AddAnswers")]
        public async Task AddAnswersAsync([FromBody] Answers answer)
        {
            try
            {
                if (answer.Id == Guid.Empty)
                {
                    answer.Id = Guid.NewGuid();
                    await this.unitOfWork.Answers.AddAsync(answer);
                }
                else
                {
                    await this.unitOfWork.Answers.UpdateAnswersAsync(answer);
                }
                this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                this.HttpContext.Response.ContentType = "text/plain";
                this.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await this.HttpContext.Response.WriteAsync("An error occurred while creating answer AddAnswersAsync API\n" + ex.Message);
            }
        }

        /// <summary>
        /// GetAnswersByquestionAsync.
        /// </summary>
        /// <param name="question">question.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
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
                var qobjs = await this.unitOfWork.Questions.GetAllAsync();
                var q = qobjs.Where(q => q.Question.Equals(question)).FirstOrDefault();
                if (q == null)
                {
                    this.HttpContext.Response.ContentType = "text/plain";
                    this.HttpContext.Response.StatusCode = (int)HttpStatusCode.NoContent;
                    await this.HttpContext.Response.WriteAsync($"question {question} not found ");
                }

                answers = this.unitOfWork.Answers.GetAllAsync().GetAwaiter().GetResult()?.Where(x => x.QuestionID == q.Id).ToList();
            }
            catch (Exception ex)
            {
                this.HttpContext.Response.ContentType = "text/plain";
                this.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await this.HttpContext.Response.WriteAsync("An error occurred while fetch questions GetQuestionsByTags API\n" + ex.Message);
            }

            return this.Ok(answers);
        }
    }
}
