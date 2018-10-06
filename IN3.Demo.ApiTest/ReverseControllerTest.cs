using System;
using Xunit;
using IN3.Demo.Api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace IN3.Demo.ApiTest
{
    public class ReverseControllerTest
    {
        [Fact]
        public void ReverseController_GetReturnOk()
        {
            var reverseController = new ReverseController();
            var okResult = reverseController.Get("");
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void ReverseController_GetReturnReversedWords()
        {
            var reverseController = new ReverseController();
            var okResult = reverseController.Get("IN3 demo reverse controller").Result as OkObjectResult;
            Assert.IsType<string>(okResult.Value);
            Assert.Equal("3NI omed esrever rellortnoc", okResult.Value);
        }
        [Fact]
        public void ReverseController_GetReturnReversedWordsOfSingleWord()
        {
            var reverseController = new ReverseController();
            var okResult = reverseController.Get("Testing").Result as OkObjectResult;
            Assert.IsType<string>(okResult.Value);
            Assert.Equal("gnitseT", okResult.Value);
        }


        [Fact]
        public void ReverseController_GetReturnReversedWordsWithPunctuations()
        {
            var reverseController = new ReverseController();
            var okResult = reverseController.Get("IN3 demo, reverse controller.").Result as OkObjectResult;
            Assert.IsType<string>(okResult.Value);
            Assert.Equal("3NI omed, esrever rellortnoc.", okResult.Value);
        }


        [Fact]
        public void ReverseController_GetReturnReversedWordsWithSymbols()
        {
            var reverseController = new ReverseController();
            var okResult = reverseController.Get("IN3 demo, reverse controller & special character.").Result as OkObjectResult;
            Assert.IsType<string>(okResult.Value);
            Assert.Equal("3NI omed, esrever rellortnoc & laiceps retcarahc.", okResult.Value);
        }

        [Fact]
        public void ReverseController_GetReturnReversedWordsWithParentheses()
        {
            var reverseController = new ReverseController();
            var okResult = reverseController.Get("IN3 demo, (reverse controller).").Result as OkObjectResult;
            Assert.IsType<string>(okResult.Value);
            Assert.Equal("3NI omed, (esrever rellortnoc).", okResult.Value);
        }
    }
}
