using SOAPZ.Common;

namespace SOAPZ.Operations.Books
{
    public class BooksRequest
    {
        public string? Title { get; set; }
        public string? AuthorName { get; set; }
        public string? Pubisher { get; set; }
        public int? YearMin { get; set; }
        public int? YearMax { get; set; }
        public string? Language { get; set; }
        public bool? IsPresent { get; set; }
        public int? PagesMin { get; set; }
        public int? PagesMax { get; set; }
    }
}
