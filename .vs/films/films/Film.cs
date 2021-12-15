using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace films
{
	public class Film
	{
		public string Title { get; set; }
		public string Overview { get; set; }
		public int Runtime { get; set; }
		public string Original_language { get; set; }
		public string Release_date { get; set; }
		public double Vote_average { get; set; }
		public string Homepage { get; set; }
		public string Poster_path { get; set; }
		public Film()
		{
		}

		public Film(string Title, string Overview, int Runtime)
		{
			this.Title    = Title;
			this.Overview = Overview;
			this.Runtime  = Runtime;
		}
	}
}