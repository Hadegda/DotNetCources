namespace OopFundamentals.OutputSystems
{
    internal class ConsoleOutput : IOutputSystem
    {
        public void ShowDocumentCards(List<Dictionary<string, string>> documentCards)
        {
            documentCards.ForEach(documentCard =>
            {
                foreach (var field in documentCard)
                {
                    Console.WriteLine($"{field.Key}:{field.Value}");
                }
                Console.WriteLine("\n");
            });
        }
    }
}
