
namespace SOAPZ_Reservation.Operations.Reservation
{
    public class ReservationRequest
    {
        public string UserId { get; set; }
        public int BookId { get; set; }
        public int ReservationCode { get; set; }
    }
}
