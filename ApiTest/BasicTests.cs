using NUnit.Framework;
using AutomationTest.Core;
using System.Net.Http;

namespace AutomationTest
{
    [TestFixture]
    public class BasicTests
    {
        [Test]
        public void TestMethodGet()
        {
            string google = "https://api.chucknorris.io/jokes/random";
            HttpResponseMessage response = WebRequest.MethodGet(google);
            string body = response.Content.ReadAsStringAsync().Result;
            Assert.IsNotEmpty(body);
        }

        [Test]
        public void TestMethodPost()
        {
            string url = "https://postman-echo.com/post";
            string message = "Random Message";
            bool result = WebRequest.MethodPost(url, message);
            Assert.IsTrue(result);
            System.Console.WriteLine($"Result: {result}");
        }

    }
}
