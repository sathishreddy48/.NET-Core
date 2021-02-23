using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTask.Models;
using WebApiTask.Repository.IRepository;

namespace WebApiTask.Repository.IRepository
{
    public interface IQuestions : IRepository<QuestionsDBEntity>
    {
    }
}
