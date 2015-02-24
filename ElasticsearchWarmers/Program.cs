using System;
using ElasticsearchWarmers.ElasticsearchProvider;

namespace ElasticsearchWarmers
{
	class Program
	{
		static void Main(string[] args)
		{
			var searchProvider = new SearchProvider();

			searchProvider.DeleteIndexIfItExists();

			searchProvider.CreateIndexWithWarmerAndAddData();
			Console.WriteLine("Added warmer when creating index");
			Console.ReadLine();

			searchProvider.AddWarmerToIndex();
			Console.WriteLine("Added warmer to index");
			Console.ReadLine();

			Console.WriteLine("search using warmer");
			Console.ReadLine();

			foreach (var item in searchProvider.Search("mph"))
			{
				Console.WriteLine("Animal: {0}, Speed in mph: {1}", item.AnimalName, item.SpeedDoubleMph);
			}

			searchProvider.DeleteWarmerFromIndex();

			Console.WriteLine("Deleted warmer from index");
			Console.ReadLine();
		}
	}
}
