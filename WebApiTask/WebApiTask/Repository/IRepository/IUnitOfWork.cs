using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTask.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ITags Tags { get; }
        IQuestions Questions { get; }
        IAnswers Answers { get; }
        IStoredProcedure StoredProcedure { get; }
    }
}
