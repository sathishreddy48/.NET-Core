using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTask.Repository.IRepository
{
    using WebApiTask.Models;
    using WebApiTask.Repository.IRepository;

    public interface IAnswers : IRepository<Answers>
    {
    }
}
