using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace simplenetcoreapp.Controllers
{
    public class VicranController : Controller
    {
        public IActionResult AboutMe()
        {
            return View();
        }
    }
}
