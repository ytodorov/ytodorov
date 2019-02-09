using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;
using Xunit;
using ytodorov.Controllers;

namespace UnitTests
{
    public class ControllerTests
    {
        [Fact]
        public void HomeTest()
        {
            HomeController controller = new HomeController();
            var res = controller.Index() as ViewResult;

            var resFromViewModel = (int)res.ViewData["test"];

            Assert.True(resFromViewModel == 1, $"1 не е равно на {resFromViewModel}");

        }

        //[Fact]
        //public void SeleniumTest()
        //{
        //    using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
        //    {
        //        driver.Navigate().GoToUrl(@"https://www.google.com");
        //    }
        //}
    }
}
