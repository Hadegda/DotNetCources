namespace OopFundamentals.DocumentStorages
{
    internal interface IDocumentStorage
    {
        List<Dictionary<string, string>> GetDocumentCardsByNumber(int documentNumber);
    }
}
