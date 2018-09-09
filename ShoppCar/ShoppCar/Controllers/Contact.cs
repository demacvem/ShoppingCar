using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppCar.Controllers
{
    public class Contact : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}
