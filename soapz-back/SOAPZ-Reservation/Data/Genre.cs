namespace SOAPZ_Reservation.Data
{
    public class Genre
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<GenreList>? GenreLists { get; set; }
    }
}
