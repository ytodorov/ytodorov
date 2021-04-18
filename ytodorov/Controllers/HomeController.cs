using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ytodorov.Models;

namespace ytodorov.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Kmp()
        {
            return View();
        }

        [Route("disqus")]
        public IActionResult Disqus(string canonicalUrl)
        {
            DisqusViewModel disqusViewModel = new DisqusViewModel()
            {
                CanonicalUrl = canonicalUrl
            };
            return View(disqusViewModel);
        }

        [Route("likebtn")]
        public IActionResult LikeBtn()
        {
            return View();
        }

        [Route("lbu")]
        public IActionResult LikeBtnUltra(string di)
        {
            string dataidentifier = di;
            if (string.IsNullOrWhiteSpace(dataidentifier))
            {
                dataidentifier = "dataidentifier";
            }
            return View((object)dataidentifier);
        }
    }
}
