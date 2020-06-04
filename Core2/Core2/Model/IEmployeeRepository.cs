using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core2.Model
{
    public interface IEmployeeRepository
    {
        public Employee GetEmployee(int id);
    }
}
