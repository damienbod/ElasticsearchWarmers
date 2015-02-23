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

			foreach (var item in searchProvider.Search("mph"))
			{
				Console.WriteLine("Animal: {0}, Speed in mph: {1}", item.AnimalName, item.SpeedDoubleMph);
			}

			Console.ReadLine();
		}
	}
}
