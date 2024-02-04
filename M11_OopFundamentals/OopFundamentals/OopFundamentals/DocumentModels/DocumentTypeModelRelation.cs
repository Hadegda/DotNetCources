using OopFundamentals.Models;

namespace OopFundamentals.DocumentModels
{
    enum DocumentType
    {
        Book,
        Patent,
        LocalisedBook,
        Magazine
    }

    internal class DocumentTypeModelRelation
    {
        public static readonly Dictionary<DocumentType, Type> DocTypeModelRelation = new()
        {
            { DocumentType.Book, typeof(Book) },
            { DocumentType.Patent, typeof(Patent) },
            { DocumentType.LocalisedBook, typeof(LocalisedBook)},
			{ DocumentType.Magazine, typeof(Magazine)}
		};
    }
}
