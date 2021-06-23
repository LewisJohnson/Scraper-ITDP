using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using api.DTOs;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ScraperAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ScraperController : ControllerBase
	{

		public static string GoogleLinkClassName = "yuRUbf";

		private readonly ILogger<ScraperController> logger;

		public ScraperController(ILogger<ScraperController> logger)
		{
			this.logger = logger;
		}

		[HttpPost]
		public IActionResult Post([FromBody] ScraperPostDTO dto)
		{
			List<string> results = new List<string>();

			string url = "https://www.google.co.uk/search?num=100&q=";

			if (!string.IsNullOrWhiteSpace(dto.Keywords))
				url += HttpUtility.UrlEncode(dto.Keywords);

			string htmlDocumentString;

			try
			{
				// We have to download the link using C# WebClient otherwise we'll end up with a Captha or Redirect :(
				WebClient client = new WebClient();
				htmlDocumentString = client.DownloadString(url);
			}
			catch (Exception e)
			{
				// Kept getting a lot of TooManyRequest responses....
				logger.LogError(e, $"Failed to download page at [URL:{ url }]");

				return StatusCode((int)HttpStatusCode.TooManyRequests);
			}

			// We didn't receive anything...
			if (string.IsNullOrWhiteSpace(htmlDocumentString))
			{
				logger.LogError($"Failed to download page at [URL:{ url }]");
				return BadRequest("Failed to fetch page.");
			}

			HtmlDocument doc = new HtmlDocument();
			doc.LoadHtml(htmlDocumentString);

			if (string.IsNullOrWhiteSpace(htmlDocumentString))
			{
				logger.LogError($"Failed to parse page at [URL:{ url }]", doc);
				return BadRequest("Failed to parse page.");
			}

			// kCrYT is a class used for links on Google
			var selectNodes = doc.DocumentNode.SelectNodes("//div[@class='kCrYT']/a");

			if (selectNodes == null)
			{
				return Ok("No results");
			}

			// Filter results
			foreach (var node in selectNodes)
			{
				//node.InnerText will give you the text content of the li tags ...
				var resUrl = node.GetAttributeValue("href", "error").Remove(0, 7);

				if (resUrl.Contains(dto.Url))
					results.Add(resUrl);
			}

			return Ok(results);
		}

		/// <summary>
		/// Axios sends an OPTIONS request for POSTS, so let's not return an error.
		/// </summary>
		/// <returns></returns>
		[HttpOptions]
		public IActionResult Options()
		{
			return Ok();
		}

	}
}
