using OopFundamentals.Models;

namespace OopFundamentals.DocumentModels
{
    enum DocumentType
    {
        Book,
        Patent,
        LocalisedBook
    }

    internal class DocumentTypeModelRelation
    {
        public static readonly Dictionary<DocumentType, Type> DocTypeModelRelation = new()
        {
            { DocumentType.Book, typeof(Book) },
            { DocumentType.Patent, typeof(Patent) },
            { DocumentType.LocalisedBook, typeof(LocalisedBook)}
        };
    }
}
