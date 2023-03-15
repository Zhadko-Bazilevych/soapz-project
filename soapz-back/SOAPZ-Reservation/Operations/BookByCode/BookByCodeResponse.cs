using SOAPZ_Reservation.Common;

namespace SOAPZ_Reservation.Operations.BookByCode
{
    public class BookByCodeResponse : BaseResponse
    {
        public ReservationsView Reservation { get; set; }

        public class ReservationsView
        {
            public string Title { get; set; }
            public int ReservationCode { get; set; }
            public string Status { get; set; }
            public DateTime? ReservationDate { get; set; }
            public DateTime? ReceivingDate { get; set; }
            public DateTime ExpirationDate { get; set; }
            public DateTime? ReturningDate { get; set; }
            public string Isbn { get; set; }
            public string? Photo { get; set; }
        }
    }
}
