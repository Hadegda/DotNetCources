using OopFundamentals.DocumentStorages;
using OopFundamentals.OutputSystems;

namespace OopFundamentals
{
    internal class Program
	{
		static void Main()
		{
			FileDocumentStorage documentStorage = new(@"D:\DotNetCources\M11_OopFundamentals\OopFundamentals\");
			ConsoleOutput consoleOutput = new();

			DocumentManager documentManager = new(documentStorage, new List<IOutputSystem>() { consoleOutput });

			documentManager.ShowDocumentsWithNumber(156);
		}
	}
}