using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace API_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();

            //Kanye Quote
            var kanyeURL = "https://api.kanye.rest";

            //Swanson Quote
            var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";

            for (int i = 0; i < 5; i++)
            {
                var kanyeResponse = client.GetStringAsync(kanyeURL).Result;

                var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();

                var ronResponse = client.GetStringAsync(ronURL).Result;

                var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();

            
                Console.WriteLine("Kanye: " + kanyeQuote);
                Console.WriteLine();
                Console.WriteLine("Ron: " + ronQuote);
                Console.WriteLine();
                Console.WriteLine("===================");
                Console.WriteLine();
            }
        }
    }
}
