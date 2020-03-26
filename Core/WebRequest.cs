using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace AutomationTest.Core
{
    public static class WebRequest
    {
        public static HttpClient client = new HttpClient();

        public static HttpResponseMessage MethodGet(string Url)
        {
            HttpRequestMessage message = new HttpRequestMessage
            {
                Method = new HttpMethod("GET"),
                RequestUri = new Uri(Url)
            };

            HttpResponseMessage response = client.SendAsync(message).Result;
            //string body = response.Content.ReadAsStringAsync().Result;
            return response;
        }

        public static bool MethodPost(string Url, string content)
        {
            HttpRequestMessage message = new HttpRequestMessage
            {
                Method = new HttpMethod("POST"),
                Content = new StringContent(content),
                RequestUri = new Uri(Url)
            };
            return client.SendAsync(message).Result.IsSuccessStatusCode;
            // string body = response.Content.ReadAsStringAsync().Result;
        }


    }
}
