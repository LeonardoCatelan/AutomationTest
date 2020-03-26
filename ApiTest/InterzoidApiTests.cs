using NUnit.Framework;
using AutomationTest.Data;
using AutomationTest.Core;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System;

namespace AutomationTest.ApiTest
{
    [TestFixture]
    public class InterzoidApiTests : Access
    {
        /// <summary>
        /// This test simulates a happy path, with the 
        /// correct inputs and server response.
        /// </summary>
        [Test]
        public void RoundRockTest()
        {
            string cityName = "Round Rock";
            string state = "TX";
            int expectedBehaviour = 200;
            string url = $"https://api.interzoid.com/getweather?license={robson.license}&city={cityName}&state={state}";

            try
            {
                HttpResponseMessage response = WebRequest.MethodGet(url);
                string body = response.Content.ReadAsStringAsync().Result;
                Assert.AreEqual((int)response.StatusCode, expectedBehaviour);
                dynamic parsedBody = JObject.Parse(body);
                string statusCode = parsedBody.Code;
                Assert.AreEqual(statusCode, "Success");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// This test force an error simulating a wrong input by the user
        /// and it won't return a valid Json body, so it will be tested only with the Http Status Code.
        /// </summary>
        [Test]
        public void TampaTest()
        {
            string cityName = "Tampa";
            string state = "TX";
            int expectedBehaviour = 404;
            string url = $"https://api.interzoid.com/getweather?license={robson.license}&city={cityName}&state={state}";
            try
            {
                HttpResponseMessage response = WebRequest.MethodGet(url);
                string body = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(body);
                Assert.AreEqual((int)response.StatusCode, expectedBehaviour);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// This test simulates a Http Status 400 (Bad Request) by not filling any fields.
        /// </summary>
        [Test]
        public void BadRequestTest()
        {
            string cityName = "";
            string state = "";
            int expectedBehaviour = 400;
            string url = $"https://api.interzoid.com/getweather?license={robson.license}&city={cityName}&state={state}";
            try
            {
                HttpResponseMessage response = WebRequest.MethodGet(url);
                string body = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(body);
                Assert.AreEqual((int)response.StatusCode, expectedBehaviour);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

    }
}
