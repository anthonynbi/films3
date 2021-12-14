using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace films
{
    class Program
    {
        public static HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            Console.WriteLine("TMDB film viewer!");
            DotNetEnv.Env.TraversePath().Load();
            string key = Environment.GetEnvironmentVariable("API_KEY");
            Console.WriteLine(key);
            var response = await client.GetAsync($"https://api.themoviedb.org/3/movie/550?api_key={key}");
            //Console.WriteLine(response.StatusCode);
            if (response.StatusCode.ToString().Equals("NotFound")){ Console.WriteLine("no dice!"); }
            else
            {
                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseContent);
                Console.WriteLine("Title: ");
                Console.WriteLine(responseContent.Substring(responseContent.IndexOf("title")) + "title".Length );
            }
        }
    }
}