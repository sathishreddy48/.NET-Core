using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Core2.Controller
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        public string Index()
        {
            return "String data";
        }
    }
}
