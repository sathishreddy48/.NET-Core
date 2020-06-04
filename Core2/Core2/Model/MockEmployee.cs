using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core2.Model
{
    public class MockEmployee : IEmployeeRepository
    {
        private List<Employee> employees = new List<Employee>();

        public MockEmployee()
        {
            employees.Add(new Employee() { ID = 1, Name = "Satheesh" });
        }
        public Employee GetEmployee(int id)
        {
            return employees.Find(x => x.ID == id);
        }
    }
}
