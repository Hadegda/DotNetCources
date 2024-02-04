using OopFundamentals.DocumentModels;

namespace OopFundamentals.DocumentStorages
{
    internal record DocumentFile(string FilePath, DocumentType DocumentType)
    {
        public string Path { get; set; } = FilePath;
        public DocumentType DocumentType { get; set; } = DocumentType;
    }
}
