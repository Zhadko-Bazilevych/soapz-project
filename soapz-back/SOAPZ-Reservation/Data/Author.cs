namespace SOAPZ_Reservation.Data
{
    public class Author
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Description { get; set; }
        public string? Photo { get; set; }
        public virtual ICollection<Book>? Books { get; set; }

    }
}
