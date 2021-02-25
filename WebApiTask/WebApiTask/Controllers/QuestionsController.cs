// <copyright file="QuestionsController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WebApiTask.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using WebApiTask.Models;
    using WebApiTask.Repository.IRepository;

    /// <summary>
    /// QuestionsController.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionsController"/> class.
        /// </summary>
        /// <param name="unit">unit.</param>
        public QuestionsController(IUnitOfWork unit)
        {
            this.unitOfWork = unit;
        }

        /// <summary>
        /// GetAllAsync.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpGet]
        [Route("GetQuestions")]
        public async Task<IEnumerable<Questions>> GetAllAsync()
        {
            try
            {
                var result = await this.unitOfWork.Questions.GetAllAsync();
                return result;
            }
            catch (Exception ex)
            {
                this.HttpContext.Response.ContentType = "text/plain";
                this.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await this.HttpContext.Response.WriteAsync("An error occurred while fetching questions GetAllAsync API\n" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// AddQuestionsAsync.
        /// </summary>
        /// <param name="question">question.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [HttpPost]
        [Route("AddQuestions")]
        public async Task<IActionResult> AddQuestionsAsync([FromBody] Questions question)
        {
            if (question == null)
            {
                this.HttpContext.Response.ContentType = "text/plain";
                this.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await this.HttpContext.Response.WriteAsync($"Parameter {nameof(question)} cannot be null or empty.");
                return this.NotFound();
            }

            try
            {
                if (question.Id == Guid.Empty)
                {
                    question.Id = Guid.NewGuid();
                    await this.unitOfWork.Questions.AddAsync(question);
                }
                else
                {
                    await this.unitOfWork.Questions.UpdateQuestionsAsync(question);
                }

                this.unitOfWork.Save();
                return this.Ok("Success");
            }
            catch (Exception ex)
            {
                this.HttpContext.Response.ContentType = "text/plain";
                this.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await this.HttpContext.Response.WriteAsync("An error occurred while creating questions AddQuestionsAsync API\n" + ex.Message);
                return this.NotFound("failed");
            }
        }

        /// <summary>
        /// GetQuestionsByTags 
        /// </summary>
        /// <param name="tags">tags.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpGet]
        [Route("GetQuestionsByTags/{tags}")]
        public async Task<IEnumerable<Questions>> GetQuestionsByTags(string tags)
        {
            if (string.IsNullOrEmpty(tags))
            {
                this.HttpContext.Response.ContentType = "text/plain";
                this.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await this.HttpContext.Response.WriteAsync($"Parameter {nameof(tags)} cannot be null or empty.");
            }

            IEnumerable<Questions> questions = null;
            try
            {
               var que = await this.unitOfWork.Questions.GetAllAsync();
               questions = que.Where(x => x.Tags.Contains(tags)).ToList();
               if (questions == null)
                {
                    this.HttpContext.Response.ContentType = "text/plain";
                    this.HttpContext.Response.StatusCode = (int)HttpStatusCode.NoContent;
                    await this.HttpContext.Response.WriteAsync($"No questions found for given tags {tags}");
                }
            }
            catch (Exception ex)
            {
                this.HttpContext.Response.ContentType = "text/plain";
                this.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await this.HttpContext.Response.WriteAsync("An error occurred while fetch questions GetQuestionsByTags API\n" + ex.Message);
            }
            //return JsonResult (new data
            return questions;
        }
    }
}
