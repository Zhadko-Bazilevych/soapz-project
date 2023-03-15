namespace SOAPZ.Data
{
    public class Reservation
    {
        public int Id { get; set; }
        public int Reservation_code { get; set; }
        public DateTime Reservation_date { get; set; }
        public DateTime? Receiving_date { get; set; }
        public DateTime Expiration_date { get; set; }
        public DateTime? Returning_date { get; set; }
        public int BookId { get; set; }
        public Book? Book { get; set; }
        public int StatusId { get; set; }
        public Status? Status { get; set; }
        public string UserId { get; set; }
        public User? User { get; set; }
    }
}
