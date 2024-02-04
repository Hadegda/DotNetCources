using OopFundamentals.DocumentModels;
using OopFundamentals.Models;
using System.Text.RegularExpressions;

namespace OopFundamentals.DocumentStorages
{
    internal class FileDocumentStorage : IDocumentStorage
    {
        private readonly Dictionary<string, DocumentType> _docTypeNames;
        private readonly string _libraryLocation;

        public FileDocumentStorage(string libraryLocation)
        {
            _docTypeNames = new()
            {
                { "book", DocumentType.Book },
                { "patent", DocumentType.Patent },
                { "localizedbook", DocumentType.LocalisedBook }
            };
            _libraryLocation = libraryLocation;
        }

        public List<Dictionary<string, string>> GetDocumentCardsByNumber(int documentNumber)
        {
            var documents = GetDocumentsByNumber(documentNumber);

            return documents.Select(document => document.GetDocumentCard()).ToList();
        }

        private List<IDocument> GetDocumentsByNumber(int documentNumber)
        {
            var documentFiles = GetDocumentFilesByNumber(documentNumber);
            var documents = new List<IDocument>();

            documentFiles.ForEach(file =>
            {
                IDocument? document = SerializationHelper.Deserialize(file.Path, DocumentTypeModelRelation.DocTypeModelRelation[file.DocumentType]);

                if (document != null)
                {
                    documents.Add(document);
                }
            });

            return documents;
        }

        private List<DocumentFile> GetDocumentFilesByNumber(int documentNumber)
        {
            var documentFiles = new List<DocumentFile>();

            foreach (var type in _docTypeNames)
            {
                Regex regex = new(@"\\" + type.Key + @"_#" + documentNumber.ToString() + @"\.json$");
                var files = Directory.EnumerateFiles(_libraryLocation).Where(f => regex.IsMatch(f));

                foreach (var file in files)
                {
                    documentFiles.Add(new DocumentFile(file, type.Value));
                }
            }

            return documentFiles;
        }
    }
}
