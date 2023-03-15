using SOAPZ_Book.Common;

namespace SOAPZ_Book.Operations.BookInfo
{
    public class BookInfoResponse : BaseResponse
    {
        public BookInfo Book { get; set; }
    }

    public class BookInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int yearPublished { get; set; }
        public string Isbn { get; set; }
        public int Pages { get; set; }
        public string? Photo { get; set; }
        public int Amount { get; set; }
        public string Author { get; set; }
        public string? AuthorPhoto { get; set; }
        public string? AuthorDescription { get; set; }
        public string PublishingHouse { get; set; }
        public string Language { get; set; }
        public List<string> Genres  { get; set; }
    }

}
