namespace SOAPZ.Data
{
    public class GenreList
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        //public virtual Book? Book { get; set; }
        public int GenreId { get; set; }
        public Genre? Genre { get; set; }
    }
}
