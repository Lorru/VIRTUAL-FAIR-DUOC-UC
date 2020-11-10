using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace VirtualFairProject.Class
{
    public class WebAPIClient
    {
        public WebAPIClient(string baseAddress)
        {
            BaseAddress = baseAddress;
            HttpClient = GetHttpClient();
        }

        private static string BaseAddress { get; set; }

        public HttpClient HttpClient { get; private set; }


        public static HttpClient GetHttpClient()
        {
            var httpClient = new HttpClient { BaseAddress = new Uri(BaseAddress) };
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }

        public T Deserialize<T>(HttpResponseMessage response) where T : class
        {
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();

            var result = response.Content;
            var content = result.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(content.Result);
        }

        public StringContent Serialize<T>(T input)
        {
            var folderAsJson = JsonConvert.SerializeObject(input);
            return new StringContent(folderAsJson, Encoding.UTF8, "application/json");
        }

    }
}
