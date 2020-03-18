using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MessageApplication.Client
{
    public class InviteData
    {
        public string[] Numbers { get; set; }
        public string Message { get; set; }
    }

    class Program
    {
        public static async Task InviteTest()
        {
            var client = new HttpClient { BaseAddress = new Uri("https://localhost:5001/") };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            List<string> numbers = new List<string>();

            long number = 79999990000;
            for (int i = 0; i < 127; i++)
            {
                numbers.Add((number++).ToString());
            }
            var inviteData = new InviteData()
            {
                Numbers = numbers.ToArray(),
                Message = "Hello World"
            };

            HttpResponseMessage response = await client.PostAsJsonAsync("api/messagesender", inviteData);
            response.EnsureSuccessStatusCode();
        }

        static void Main(string[] args)
        {
            InviteTest().GetAwaiter().GetResult();

            Console.ReadLine();
        }
    }
}
