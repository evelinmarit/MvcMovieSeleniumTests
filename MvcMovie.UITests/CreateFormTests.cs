using System;
using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MvcMovie.UITests
{
    public class CreateFormTests : IDisposable
    {
        private readonly IWebDriver _webDriver;

        public CreateFormTests()
        {
            var options = new ChromeOptions();
            // Kommenteeri sisse kui tahad brauseri akna peita
            //options.AddArgument("--headless");

            _webDriver = new ChromeDriver(options);
            _webDriver.Navigate().GoToUrl("https://localhost:7292/Movies/Create");
        }

        [Fact]
        public void Can_navigate_to_create_form()
        {
            // Arrange
            // Act

            // Assert
            Assert.StartsWith("Create -", _webDriver.Title);
        }

        [Fact]
        public void Displays_validation_error_for_empty_title()
        {
            // Arrange
            var createButton = _webDriver.FindElement(By.ClassName("btn-primary"));
            var expectedValidationText = "The Title field is required.";

            // Act
            createButton.Click();

            // Assert
            var titleValidationElement = _webDriver.FindElement(By.Id("Title-error"));
            Assert.NotNull(titleValidationElement);
            Assert.True(titleValidationElement.Displayed);
            Assert.Equal(expectedValidationText, titleValidationElement.Text);
        }

        [Fact]
        public void Displays_validation_error_for_too_short_title()
        {
            // Arrange
            var titleField = _webDriver.FindElement(By.Id("Title"));
            var expectedValidationText = "The field Title must be a string with a minimum length of 3 and a maximum length of 60.";

            // Act
            titleField.SendKeys("AD");
            titleField.SendKeys("\t");

            // Assert
            var titleValidationElement = _webDriver.FindElement(By.Id("Title-error"));
            Assert.NotNull(titleValidationElement);
            Assert.True(titleValidationElement.Displayed);
            Assert.Equal(expectedValidationText, titleValidationElement.Text);
        }        

        [Fact]
        public void Validation_error_is_not_displayed_for_valid_title()
        {
            // Arrange
            var titleField = _webDriver.FindElement(By.Id("Title"));

            // Act
            titleField.SendKeys("Kill Bill");
            titleField.SendKeys("\t");

            // Assert
            try
            {
                _webDriver.FindElement(By.Id("Title-error"));
                throw new Exception("Title validation field was found");
            }
            catch (NoSuchElementException) { }
        }

        [Fact]
        public void Displays_validation_error_for_empty_genre()
        {
            // Arrange
            var createButton = _webDriver.FindElement(By.ClassName("btn-primary"));
            var expectedValidationText = "The Genre field is required.";

            // Act
            createButton.Click();

            // Assert
            var genreValidationElement = _webDriver.FindElement(By.Id("Genre-error"));
            Assert.NotNull(genreValidationElement);
            Assert.True(genreValidationElement.Displayed);
            Assert.Equal(expectedValidationText, genreValidationElement.Text);
        }

        [Fact]
        public void Displays_validation_error_for_genre_with_numbers()
        {
            // Arrange
            var genreField = _webDriver.FindElement(By.Id("Genre"));
            var expectedValidationText = "The field Genre must match the regular expression '^[A-Z]+[a-zA-Z\\s]*$'.";

            // Act
            genreField.SendKeys("12");
            genreField.SendKeys("\t");

            // Assert
            var genreValidationElement = _webDriver.FindElement(By.Id("Genre-error"));
            Assert.NotNull(genreValidationElement);
            Assert.True(genreValidationElement.Displayed);
            Assert.Equal(expectedValidationText, genreValidationElement.Text);
        }

        [Fact]
        public void Validation_error_is_not_displayed_for_valid_genre()
        {
            // Arrange
            var genreField = _webDriver.FindElement(By.Id("Genre"));

            // Act
            genreField.SendKeys("Comedy");
            genreField.SendKeys("\t");

            // Assert
            try
            {
                _webDriver.FindElement(By.Id("Genre-error"));
                throw new Exception("Genre validation field was found");
            }
            catch (NoSuchElementException) { }
        }

        [Fact]
        public void Displays_validation_error_for_empty_price()
        {
            // Arrange
            var createButton = _webDriver.FindElement(By.ClassName("btn-primary"));
            var expectedValidationText = "The Price field is required.";

            // Act
            createButton.Click();

            // Assert
            var priceValidationElement = _webDriver.FindElement(By.Id("Price-error"));
            Assert.NotNull(priceValidationElement);
            Assert.True(priceValidationElement.Displayed);
            Assert.Equal(expectedValidationText, priceValidationElement.Text);
        }

        [Fact]
        public void Displays_validation_error_for_price_with_letters()
        {
            // Arrange
            var priceField = _webDriver.FindElement(By.Id("Price"));
            var expectedValidationText = "The field Price must be a number.";

            // Act
            priceField.SendKeys("2f");
            priceField.SendKeys("\t");

            // Assert
            var priceValidationElement = _webDriver.FindElement(By.Id("Price-error"));
            Assert.NotNull(priceValidationElement);
            Assert.True(priceValidationElement.Displayed);
            Assert.Equal(expectedValidationText, priceValidationElement.Text);
        }

        [Fact]
        public void Validation_error_is_not_displayed_for_valid_price()
        {
            // Arrange
            var priceField = _webDriver.FindElement(By.Id("Price"));

            // Act
            priceField.SendKeys("12");
            priceField.SendKeys("\t");

            // Assert
            try
            {
                _webDriver.FindElement(By.Id("Price-error"));
                throw new Exception("Price validation field was found");
            }
            catch (NoSuchElementException) { }
        }

        [Fact]
        public void Displays_validation_error_for_empty_rating()
        {
            // Arrange
            var createButton = _webDriver.FindElement(By.ClassName("btn-primary"));
            var expectedValidationText = "The Rating field is required.";

            // Act
            createButton.Click();

            // Assert
            var ratingValidationElement = _webDriver.FindElement(By.Id("Rating-error"));
            Assert.NotNull(ratingValidationElement);
            Assert.True(ratingValidationElement.Displayed);
            Assert.Equal(expectedValidationText, ratingValidationElement.Text);
        }

        [Fact]
        public void Displays_validation_error_for_rating_with_numbers()
        {
            // Arrange
            var ratingField = _webDriver.FindElement(By.Id("Rating"));
            var expectedValidationText = "The field Rating must match the regular expression '^[A-Z]+[a-zA-Z0-9\"'\\s-]*$'.";

            // Act
            ratingField.SendKeys("2f");
            ratingField.SendKeys("\t");

            // Assert
            var ratingValidationElement = _webDriver.FindElement(By.Id("Rating-error"));
            Assert.NotNull(ratingValidationElement);
            Assert.True(ratingValidationElement.Displayed);
            Assert.Equal(expectedValidationText, ratingValidationElement.Text);
        }

        [Fact]
        public void Validation_error_is_not_displayed_for_valid_rating()
        {
            // Arrange
            var ratingField = _webDriver.FindElement(By.Id("Rating"));

            // Act
            ratingField.SendKeys("R");
            ratingField.SendKeys("\t");

            // Assert
            try
            {
                _webDriver.FindElement(By.Id("Rating-error"));
                throw new Exception("Rating validation field was found");
            }
            catch (NoSuchElementException) { }
        }

        [Fact]
        public void Can_navigate_to_movie_list_after_fill_in_form()
        {
            // Arrange
            var createButton = _webDriver.FindElement(By.ClassName("btn-primary"));

            // Act
            createButton.Click();

            // Assert
            _webDriver.Navigate().GoToUrl("https://localhost:7292/Movies");
            Assert.StartsWith("Index -", _webDriver.Title);
        }


        public void Dispose()
        {
            // Kommenteeri need read sisse kui tahad brauseri akna lahti jätta
            //_webDriver.Quit();
            //_webDriver.Dispose();
        }
    }
}