namespace SOAPZ_Reservation.Data
{
    public class Book
    {
        public int Id { get; set; }
        public string Title{ get; set; }
        public string Description { get; set; }
        public int YearPublished { get; set; }
        public string Isbn { get; set; }
        public int Pages { get; set; }
        public string? Photo { get; set; }
        public int Amount { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public int PublishingHouseId { get; set; }
        public PublishingHouse PublishingHouse { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        public ICollection<GenreList>? genre { get; set; }


    }
}
