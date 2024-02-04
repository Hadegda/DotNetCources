using OopFundamentals.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopFundamentals.DocumentModels
{
	internal class Magazine : IDocument
	{
		public string Title { get; set; } = string.Empty;
		public string Publisher { get; set; } = string.Empty;
		public DateTime PublishDate { get; set; }
		public int ReleaseNumber { get; set; }

		public Dictionary<string, string> GetDocumentCard()
		{
			Dictionary<string, string> documentCard = new()
			{
				{ "title", Title },
				{ "publisher", Publisher },
				{ "release number", ReleaseNumber.ToString() },
				{ "date published", PublishDate.ToString(CultureInfo.InvariantCulture) },
			};

			return documentCard;
		}
	}
}
