using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;
using ytodorov.Controllers;

namespace UnitTests
{
    public class ControllerTests
    {
        [Fact]
        public void Home()
        {
            HomeController controller = new HomeController();
            var res = controller.Index() as ViewResult;

            var resFromViewModel = (int)res.ViewData["test"];

            Assert.Equal<int>(resFromViewModel, 1);

        }
    }
}
