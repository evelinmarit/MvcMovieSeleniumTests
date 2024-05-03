using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcMovie.UITests
{
    public class CreateIndexTests : IDisposable
    {
        private readonly IWebDriver _webDriver;

        public CreateIndexTests()
        {
            var options = new ChromeOptions();
            // Kommenteeri sisse kui tahad brauseri akna peita
            //options.AddArgument("--headless");

            _webDriver = new ChromeDriver(options);
            _webDriver.Navigate().GoToUrl("https://localhost:7292/Movies");
        }

        [Fact]
        public void Can_navigate_to_list_of_movies()
        {
            // Arrange
            // Act

            // Assert
            Assert.StartsWith("Index -", _webDriver.Title);
        }

        [Fact]

        public void Dispose()
        {
            // Kommenteeri need read sisse kui tahad brauseri akna lahti jätta
            //_webDriver.Quit();
            //_webDriver.Dispose();
        }
    }
}
