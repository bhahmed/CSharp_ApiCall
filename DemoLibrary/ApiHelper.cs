using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DemoLibrary
{
    public class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }

        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            // ApiClient.BaseAddress = new Uri("http://xkcd.com/");
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("appliaction/json"));
        }
    }
}
