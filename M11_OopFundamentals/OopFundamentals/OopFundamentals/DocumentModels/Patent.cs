using System.Globalization;

namespace OopFundamentals.Models
{
    internal class Patent : IDocument
    {
		public string Title { get; set; } = string.Empty;
		public List<string> Authors { get; set; } = new List<string>();
		public DateTime PublishDate { get; set; }
		public DateTime ExpirationDate { get; set; }
		public int Id { get; set; }

		public Dictionary<string, string> GetDocumentCard()
		{
			Dictionary<string, string> documentCard = new()
			{
				{ "title", Title },
				{ "authors", String.Join(',', Authors) },
				{ "date published", PublishDate.ToString(CultureInfo.InvariantCulture) },
				{ "expiration date", ExpirationDate.ToString(CultureInfo.InvariantCulture) },
				{ "unique id", Id.ToString() },
			};

			return documentCard;
		}
	}
}
