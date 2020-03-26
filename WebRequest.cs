using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace AutomationTest
{
    public static class WebRequest
    {
        public static HttpClient client = new HttpClient();

        public static string GetMethod(string Url)
        {
            HttpRequestMessage message = new HttpRequestMessage
            {
                Method = new HttpMethod("GET"),
                RequestUri = new Uri(Url)
            };
            var response = client.SendAsync(message).Result;
            string body = response.Content.ReadAsStringAsync().Result;
            return body;
        }
    }
}
