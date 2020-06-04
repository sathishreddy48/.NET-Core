using Core2.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Core2.Controller
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private IEmployeeRepository EmployeeRepository;
        
        public HomeController(IEmployeeRepository employee)
        {
            EmployeeRepository = employee;
        }
        public string Index()
        {
            return EmployeeRepository.GetEmployee(1).Name;
        }
    }
}
