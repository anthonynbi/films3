using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace films
{

    class SearchFilm
    {
        public static HttpClient client  = new HttpClient();
        public static HttpClient client2 = new HttpClient();
        public static async Task Run()
        {
            DotNetEnv.Env.TraversePath().Load();
            string key = Environment.GetEnvironmentVariable("API_KEY");
            Console.WriteLine("search movie:");
            string input_search = Console.ReadLine();
            var response = await client.GetAsync($"https://api.themoviedb.org/3/search/movie?api_key={key}&query={input_search}");
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            //Console.WriteLine(responseContent);

            string s = responseContent.Substring(responseContent.IndexOf('[')+2);
            s = s.Substring(0, s.LastIndexOf(']')-1);
            string[] sfJson = s.Split("},{");
            List<FilmQueryResult> result = new List<FilmQueryResult>();
            foreach (string sfj in sfJson)
            {
                result.Add(JsonConvert.DeserializeObject<FilmQueryResult>("{"+sfj+"}"));
            }

            //Console.WriteLine(s.Split("},{")[0]);
            //Console.WriteLine(s.Split("},{")[19]);

            Console.WriteLine("\nTitles:");
            int index = 1;
            foreach (FilmQueryResult r in result)
            {
                Console.Write((index++)+") ");
                Console.WriteLine(r.Title);
            }
            int select = -1;
            while(true)
            { 
                Console.WriteLine("Select title by index: ");
                bool exit_loop = int.TryParse(Console.ReadLine(), out select);
                if (exit_loop) { break; }
            }
            select--;
            //Console.WriteLine("\nTitle: ");
            //Console.WriteLine(result[select].Title);

            var response2 = await client2.GetAsync($"https://api.themoviedb.org/3/movie/{result[select].Id}?api_key={key}");
            response2.EnsureSuccessStatusCode();
            var responseContent2 = await response2.Content.ReadAsStringAsync();
            Film film = JsonConvert.DeserializeObject<Film>(responseContent2);

            Console.WriteLine("");
            Console.WriteLine($"Title: {film.Title}");
            Console.WriteLine($"Overview: {film.Overview}");
            Console.WriteLine($"Runtime: {film.Runtime}");
            Console.WriteLine($"Release date: {film.Release_date}");
            Console.WriteLine($"Vote Average: {film.Vote_average}");
            Console.WriteLine($"Homepage: {film.Homepage}");
            Console.WriteLine($"Poster: {Program.PosterBase}{film.Poster_path}");
            Console.Write($"Original language: {film.Original_language}");
            Console.WriteLine("-"+ Program.lang[film.Original_language]);

        }
    }
}