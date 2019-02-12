using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace QuoteMeSenpai.Models
{
    public class Quote
    {
        private static readonly HttpClient client = new HttpClient();

        public readonly string Content;
        public readonly string Citation;

        public Quote()
        {
            Citation = RequestCitation();
            Content = RequestContent().Result;
        }

        private string RequestCitation()
        {
            Random random = new Random();
            string[] names;
            int randomIndex;

            using (StreamReader r = new StreamReader("wwwroot/dist/assets/celebrities.json")) 
            {
                JArray line = JArray.Parse(r.ReadLine());
                names = line.Select(jv => (string)jv).ToArray();
                randomIndex = random.Next(names.Length);
            }

            return names[randomIndex];
        }

        private async Task<string> RequestContent()
        {
            var response = await client.GetStringAsync("https://talaikis.com/api/quotes/random/");
            JObject content = JObject.Parse(response);

            return (string)content.SelectToken("quote");
        }

    }
}
