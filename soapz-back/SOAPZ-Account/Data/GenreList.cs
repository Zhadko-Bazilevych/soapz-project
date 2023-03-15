namespace SOAPZ_Account.Data
{
    public class GenreList
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public virtual Book? Book { get; set; }
        public int GenreId { get; set; }
        public virtual Genre? Genre { get; set; }
    }
}
