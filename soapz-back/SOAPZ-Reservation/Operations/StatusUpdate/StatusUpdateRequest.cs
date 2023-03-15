using SOAPZ_Reservation.Common;

namespace SOAPZ_Reservation.Operations.StatusUpdate
{
    public class StatusUpdateRequest
    {
        public int ReservationCode { get; set; }
        public string Status { get; set; }
    }
}
