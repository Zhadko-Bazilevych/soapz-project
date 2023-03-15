using SOAPZ.Common;

namespace SOAPZ.Operations.StatusUpdate
{
    public class StatusUpdateRequest
    {
        public int ReservationCode { get; set; }
        public string Status { get; set; }
    }
}
