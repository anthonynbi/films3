using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace films
{
    class DisplayFilm
    {
        public static HttpClient client = new HttpClient();
        public static async Task Run()
        {

            DotNetEnv.Env.TraversePath().Load();
            string key = Environment.GetEnvironmentVariable("API_KEY");
            Console.WriteLine("input movie ID:");
            string input_id = Console.ReadLine();
            var response = await client.GetAsync($"https://api.themoviedb.org/3/movie/{input_id}?api_key={key}");
            if (response.StatusCode.ToString().Equals("NotFound")) { Console.WriteLine("Movie not found!"); }
            else
            {
                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync();
                Film film = JsonConvert.DeserializeObject<Film>(responseContent);

                Console.WriteLine("");
                Console.WriteLine($"Title: {film.Title}");
                Console.WriteLine($"Overview: {film.Overview}");
                Console.WriteLine($"Runtime: {film.Runtime}");
                Console.WriteLine($"Release date: {film.Release_date}");
                Console.WriteLine($"Vote Average: {film.Vote_average}");
                Console.WriteLine($"Homepage: {film.Homepage}");
                Console.WriteLine($"Poster: {Program.PosterBase}{film.Poster_path}");
                Console.Write($"Original language: {film.Original_language}");
                Console.WriteLine("-"+ Program.lang[film.Original_language] );
            }
        }
    }
}