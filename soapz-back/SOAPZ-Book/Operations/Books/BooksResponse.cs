using SOAPZ_Book.Common;

namespace SOAPZ_Book.Operations.Books
{
    public class BooksResponse : BaseResponse
    {
        public ICollection<BooksView>? Books { get; set; }
        public int Count { get; set; }

        public class BooksView
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public int YearPublished { get; set; }
            public int Pages { get; set; }
            public int Amount { get; set; }
            public string PublishingHouse { get; set; }
            public string Language { get; set; }
            public string Author { get; set; }
            public string Photo { get; set; }
        }
    }
}
