using NUnit.Framework;
using AutomationTest.Core;


namespace AutomationTest
{
    [TestFixture]
    public class BasicTests
    {
        [Test]
        public void TestMethodGet()
        {
            string google = "https://api.chucknorris.io/jokes/random";
            string result = WebRequest.MethodGet(google);
            Assert.IsNotEmpty(result);
            System.Console.WriteLine(result);
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
