using OopFundamentals.DocumentStorages;
using OopFundamentals.OutputSystems;

namespace OopFundamentals
{
	internal class DocumentManager
	{
		private readonly IDocumentStorage _documentStorage;
		private readonly List<IOutputSystem> _outputSystems;

		public DocumentManager (IDocumentStorage documentStorage, List<IOutputSystem> outputSystems)
		{
			_documentStorage = documentStorage;
			_outputSystems = outputSystems;
		}

		public void ShowDocumentsWithNumber(int documentNumber)
		{
			var documentCards = _documentStorage.GetDocumentCardsByNumber(documentNumber);

			_outputSystems.ForEach(outputSystem => {
				outputSystem.ShowDocumentCards(documentCards);
			});
		}
	}
}
