using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using ytodorov.Models;

namespace ytodorov.Controllers
{
    public class TestController : Controller
    {
        public IActionResult GetTime()
        {
            Thread.Sleep(3000);
            return Json(DateTime.Now);
        }
    }
}
