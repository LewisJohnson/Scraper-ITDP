using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scraper_ITDP.Models
{
	public class ResultsViewModel
	{
		public ResultsViewModel()
		{
			Results = new Dictionary<string, int>();
		}

		public ResultsViewModel(Dictionary<string, int> results)
		{
			Results = results ?? throw new ArgumentNullException(nameof(results));
		}

		public Dictionary<string, int> Results { get; set; }
	}
}
