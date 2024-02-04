﻿using System.Globalization;

namespace OopFundamentals.Models
{
    internal class LocalisedBook : IDocument
    {
		public int Isbn { get; set; }
		public string Title { get; set; } = string.Empty;
		public List<string> Authors { get; set; } = new List<string>();
		public int PagesCount { get; set; }
		public string Publisher { get; set; } = string.Empty;
		public DateTime PublishDate { get; set; }
		public string LocalPublisher { get; set; } = string.Empty;
		public string LocalizationCountry { get; set; } = string.Empty;

		public Dictionary<string, string> GetDocumentCard()
		{
			Dictionary<string, string> documentCard = new()
			{
				{ "ISBN", Isbn.ToString() },
				{ "title", Title },
				{ "authors", String.Join(',', Authors) },
				{ "number of pages", PagesCount.ToString() },
				{ "original publisher", Publisher },
				{ "country of localization", LocalizationCountry },
				{ "local publisher", LocalPublisher },
				{ "date published", PublishDate.ToString(CultureInfo.InvariantCulture) },
			};

			return documentCard;
		}
    }
}
